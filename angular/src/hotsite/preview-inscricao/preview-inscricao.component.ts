import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FgvCarrousselImagem } from '@app/shared/component/fgv-carroussel/fgv-carroussel.component';
import { FgvMenuHorizontalItemMenu, FgvMenuHorizontalLogo } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.component';
import { GenericItem } from '@app/shared/component/GenericItem';
import { HotSiteInCompanyServiceProxy, InputDownloadObjectDto } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'abp-ng2-module/dist/src/message/message.service';
import { HotSiteMasterPageComponent } from 'hotsite/hotsite-master-page/hotsite-master-page.component';
import { SelectItem } from 'primeng/api';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'preview-inscricao',
    templateUrl: './preview-inscricao.component.html',
    styleUrls: ['./preview-inscricao.component.css']
})
export class PreviewInscricaoComponent implements OnInit {
    @ViewChild('masterPage') masterPage: HotSiteMasterPageComponent;
    private message: MessageService;
    private loadingCount: number[] = [];
    private activatedRoute: ActivatedRoute;
    private router: Router;
    private _hotSiteInCompanyService: HotSiteInCompanyServiceProxy;
    formInscricao: FormGroup;
    formBuilder: FormBuilder;
    idHotSiteInCompany: number;
    turmas: SelectItem[] = [];
    buttonInscreverStyle: any;
    exibirFormulario: boolean;

    constructor(injector: Injector) {
        this.formBuilder = injector.get(FormBuilder);
        this.router = injector.get(Router);
        this.message = injector.get(MessageService);
        this.activatedRoute = injector.get(ActivatedRoute);
        this._hotSiteInCompanyService = injector.get(HotSiteInCompanyServiceProxy);
    }

    ngOnInit() {
        this.geraFormulario();
        let usuarioLogado: boolean = false;
        this.activatedRoute.params.subscribe(x => {
            this.getHotSiteInCompany(x.nomeHotSite, usuarioLogado);
        });
    }

    geraFormulario() {
        this.formInscricao = this.formBuilder.group({
            cpf: ['', Validators.required],
            email: ['', Validators.required],
            idTurma: ['', Validators.required],
        });
    }

    getHotSiteInCompany(nomeHotSite: string, usuarioLogado: boolean): void {

        if (nomeHotSite == null) {
            this.message.error('HotSite não informado.');
            return;
        }

        this.showLoading();

        this._hotSiteInCompanyService.buscarHotSiteInCompanyByNome(nomeHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x == null || x.id == null) {
                    this.message.error('HotSite não encontrado.');
                    this.exibirFormulario = false;
                }
                else {
                    if (x.publicado && !x.excluido) {
                        this.router.navigateByUrl('inscricao/' + x.nomeHotSite);
                    } else {
                        this.exibirFormulario = true;
                        this.idHotSiteInCompany = x.id;
                        this.carregarconfiguracao(x.id);
                        this.carregarMenu(x.id, x.nomeHotSite, usuarioLogado);
                        this.carregarCarroussel(x.id);
                        this.carregarLogo(x.id);
                        this.carregarTurmas(x.id);
                    }
                }
            });
    }

    carregarconfiguracao(idHotSite: number): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x != null) {
                    this.masterPage.menu.styleBarraMenu = { 'background-color': x.corBarraMenu };
                    this.masterPage.styleTitulo = { 'color': x.corTitulo };
                    this.masterPage.styleFundo = { 'background-color': x.corFundo };
                    this.masterPage.setBackgroundColor(x.corFundo);
                    this.buttonInscreverStyle = { 'background-color': x.corBarraMenu, 'border-color': x.corBarraMenu };
                }
            });
    }

    carregarCarroussel(idHotSite: number): void {
        this.masterPage.clearImagemCarroussel();

        this.showLoading();

        this._hotSiteInCompanyService.buscarCarrosselPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                x.forEach(y => {
                    if (y != null && y.token != null && y.token != '') {
                        let input = new InputDownloadObjectDto();
                        input.token = y.token;

                        this.showLoading();

                        this._hotSiteInCompanyService.downloadBinaryObject(input)
                            .pipe(finalize(() => { this.hideLoading(); }))
                            .subscribe(z => {
                                if (z != null && z.bytes != null && z.bytes != '') {
                                    let i = new FgvCarrousselImagem();
                                    i.src = 'data:image/png;base64,' + z.bytes;
                                    i.titulo = y.nome;
                                    i.url = '';

                                    this.masterPage.addImagemCarroussel(i);
                                }
                            });
                    }
                });
            });
    }

    carregarMenu(idHotSite: number, nomeHotSite: string, usuarioLogado: boolean): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuPorIdHotSite(idHotSite, usuarioLogado)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {

                let menus = x.sort((a, b) => a.ordem.toString().localeCompare(b.ordem.toString()))
                    .map(y => {
                        if (this.router.url.indexOf(y.rota) != -1) {
                            this.masterPage.titulo = y.titulo;
                        }

                        let url = '/preview/hotsite/' + nomeHotSite;

                        let m = new FgvMenuHorizontalItemMenu();
                        m.identificador = y.id;
                        m.titulo = y.descricao
                        m.url = y.rota == null || y.rota == '' ? url + '/' + y.id : y.rota;

                        m.subMenu = y.subMenus.map(z => {
                            let s = new FgvMenuHorizontalItemMenu();
                            s.identificador = z.id;
                            s.titulo = z.descricao;
                            s.url = z.rota == null || z.rota == '' ? url + '/' + z.id : z.rota;

                            return s;
                        });

                        return m;
                    });

                this.masterPage.carregarMenu(menus);
            });
    }

    carregarLogo(idHotSite: number): void {
        this.masterPage.clearLogo();

        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                this.addLogo(x.logoFGV, 'FGV', '');
                this.addLogo(x.logoEmpresa1, '', '');
                this.addLogo(x.logoEmpresa2, '', '');
            });
    }

    carregarTurmas(idHotSite: number): void {
        this.turmas = [];

        this.showLoading();

        let cpfPassaporte = this.formInscricao.controls.cpf.value;

        this._hotSiteInCompanyService.buscarTurmaPorIdHotSite(idHotSite,cpfPassaporte)
        .pipe(finalize(() => { this.hideLoading(); }))
        .subscribe(x => {             

            if (x.sucesso == false){
                this.message.error(x.mensagem );
                this.turmas = [];
                return;
            }

            if (x.item != null) {
                x.item.forEach(y => this.turmas.push(new GenericItem(y.getTurmaCurso, y.codigoTurma)));
            }
        });

       
    }

    addLogo(token: string, titulo: string, url: string): void {
        if (token == null || token == '') {
            return;
        }

        let input = new InputDownloadObjectDto();
        input.token = token;

        this.showLoading();

        this._hotSiteInCompanyService.downloadBinaryObject(input)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(y => {
                if (y != null && y.bytes != null && y.bytes != '') {
                    let logoFGV = new FgvMenuHorizontalLogo();
                    logoFGV.identificador = token;
                    logoFGV.titulo = titulo;
                    logoFGV.url = url;
                    logoFGV.src = 'data:image/png;base64,' + y.bytes;

                    this.masterPage.addLogo(logoFGV);
                }
            });
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

    menuOnClick(obj: FgvMenuHorizontalItemMenu): void {
        if (obj == null || obj.url == null || obj.url == '') {
            return;
        }

        if (obj.url.indexOf('https://') != -1 || obj.url.indexOf('http://') != -1) {
            window.location.href = obj.url;
        } else {
            this.router.navigateByUrl(obj.url);
        }
    }

    buttonInscreverOnClick(): void {
        if (this.formInscricao.invalid) {
            this.validarCampos(this.formInscricao);
        }

        this.message.error('Não é permitido realizar inscrição.');
    }

    private validarCampos(formulario: FormGroup) {
        Object.keys(formulario.controls).forEach((campo) => {
            const control = formulario.get(campo);
            if (control instanceof FormControl) {
                control.markAsTouched({ onlySelf: true });
            } else if (control instanceof FormGroup) {
                this.validarCampos(control);
            }
        });
    }
}
