import { Component, Injector, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HotSiteInCompanyServiceProxy, InputDownloadObjectDto } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'abp-ng2-module/dist/src/message/message.service';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'documento-download',
    templateUrl: './documento-download.component.html',
    styleUrls: ['./documento-download.component.css']
})
export class DocumentoDownloadComponent implements OnInit, AfterViewInit {

    private message: MessageService;
    private activatedRoute: ActivatedRoute;
    private loadingCount: number[] = [];
    private _hotSiteInCompanyService: HotSiteInCompanyServiceProxy;

    constructor(injector: Injector) {
        this.message = injector.get(MessageService);
        //this.message.info("Download em andamento.");
        this.activatedRoute = injector.get(ActivatedRoute);
        this._hotSiteInCompanyService = injector.get(HotSiteInCompanyServiceProxy);
    }

    ngOnInit() {
        this.showLoading();
        this.activatedRoute.params.subscribe(x => {
            this.getDocumento(x.token);
        });
    }

    ngAfterViewInit(): void {
        this.hideLoading();
    }

    getDocumento(token: string): void {
        if (token == null || token == '') {
            return;
        }

        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuDocumentoPublicadoPorToken(token)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {

                if (x == null || x.id == null) {
                    this.showLoading();

                    this._hotSiteInCompanyService.buscarMenuDocumentoPorToken(token)
                        .pipe(finalize(() => { this.hideLoading(); }))
                        .subscribe(y => {
                            if (y == null || y.id == null) {
                                this.message.error('Documento não encontrado.');
                            } else {
                                this.getDocumentoBytes(y.token, y.nome);
                            }
                        });
                } else {
                    this.getDocumentoBytes(x.token, x.nome);
                }
            });
    }

    getDocumentoBytes(token: string, nomeDocumento: string): void {
        if (token == null || token == '') {
            this.message.error('Documento não encontrado.');
            return;
        }

        let input = new InputDownloadObjectDto();
        input.token = token;

        this.showLoading();

        this._hotSiteInCompanyService.downloadBinaryObject(input)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(y => {
                if (y == null || y.bytes == null || y.bytes == '') {
                    this.message.error('Documento não encontrado.');
                } else {
                    this.downloadArquivo(y.bytes, nomeDocumento);
                    //this.message.info("Download finalizado.");
                    this.fecharAba();
                }
            });
    }

    downloadArquivo(fileBytes: string, nomeDocumento: string): void {

        let bytes: Uint8Array;

        if (fileBytes != null && fileBytes.length > 0) {
            bytes = this.base64ToArrayBuffer(fileBytes);
        } else {
            bytes = this.base64ToArrayBuffer('');
        }

        this.gerarArquivo(bytes, nomeDocumento, '');

        return;
    }

    base64ToArrayBuffer(base64): Uint8Array {
        let binaryString = window.atob(base64);
        let binaryLen = binaryString.length;
        let bytes = new Uint8Array(binaryLen);
        for (let i = 0; i < binaryLen; i++) {
            let ascii = binaryString.charCodeAt(i);
            bytes[i] = ascii;
        }
        return bytes;
    }

    gerarArquivo(bytes: Uint8Array, nome: string, mimeType: string): void {
        this.showLoading();

        let urlCreator = window.URL;
        let blob = new Blob([bytes], { type: mimeType });
        let url = urlCreator.createObjectURL(blob);
        let link = document.createElement('a');
        link.setAttribute('href', url);
        link.setAttribute('download', nome);

        let evento = document.createEvent('MouseEvents');
        evento.initMouseEvent('click', true, true, window, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
        link.dispatchEvent(evento);

        this.hideLoading();
    }

    showLoading(): void {
        this.loadingCount.push(1);
        abp.ui.setBusy();
    }

    hideLoading(): void {
        this.loadingCount = this.loadingCount.slice(1)

        if (this.loadingCount.length <= 0) {
            abp.ui.clearBusy();
        }
    }

    fecharAba(): void {
        setTimeout(() => {
            window.close();
        }, 2000);
    }
}
