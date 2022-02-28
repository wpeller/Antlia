import { Component, EventEmitter, Injector, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PrimengTableHelper } from '@shared/helpers/PrimengTableHelper';
import { ModalDirective, document } from 'ngx-bootstrap';
import { FgvInputFile_File } from './fgv-input-file.model';

@Component({
    selector: 'fgv-input-file',
    templateUrl: './fgv-input-file.component.html',
    styleUrls: ['./fgv-input-file.component.css'],
})
export class FgvInputFileComponent extends AppComponentBase implements OnInit {
    @Input() id: string = '';
    @Input() buttonLabel: string = "Anexar";
    @Input() multiple: boolean = true;
    @Input() maxMbFileAll: number = 10;
    @Input() maxMbFile: number = 10;
    @Input() formatosPermitidos: string[] = ['.pdf', '.doc', '.docx', '.png', '.jpg', '.jpeg'];
    @Input() exibirColunas: number[] = [0, 1, 2, 3, 4, 5, 6, 7];
    @Input() exibirBotaoAcao: number[] = [0, 1, 2];
    @Input() arquivos: FgvInputFile_File[] = [];

    @Output() onAddArquivo: EventEmitter<FgvInputFile_File> = new EventEmitter<FgvInputFile_File>();
    @Output() onDelArquivo: EventEmitter<number> = new EventEmitter<number>();
    @Output() onDownloadArquivo: EventEmitter<FgvInputFile_File> = new EventEmitter<FgvInputFile_File>();

    @ViewChild('Modal') modal: ModalDirective;

    formatosPermitidosTexto: string = '';
    modalFile: FgvInputFile_File = new FgvInputFile_File();

    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit() {
        this.id = this.newGuid();
        this.loadGrid();
        this.preencherFormatosPermitidosTexto();
    }

    newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    loadGrid(): void {

        if (this.primengTableHelper == null) {
            this.primengTableHelper = new PrimengTableHelper();
        }

        this.showLoading();

        let linha = 0;

        let files = this.arquivos.map(x => {
            linha = linha + 1;
            return { index: linha, item: x };
        });

        this.primengTableHelper.records = files;
        this.primengTableHelper.totalRecordsCount = files.length;

        this.hideLoading();
    }

    private preencherFormatosPermitidosTexto(): void {
        this.formatosPermitidosTexto = '';

        for (var i = 0; i < this.formatosPermitidos.length; i++) {

            this.formatosPermitidosTexto += this.formatosPermitidos[i];

            if (i < this.formatosPermitidos.length - 1) {
                this.formatosPermitidosTexto += ', ';
            }
        }
    }

    exibirColuna(coluna: number): boolean {

        if (this.exibirColunas == null || this.exibirColunas.length <= 0) {
            return true;
        }

        if (coluna < 0) {
            return false;
        }

        return this.exibirColunas.some(x => x == coluna);
    }

    exibirBotao(botao: number): boolean {

        if (this.exibirBotaoAcao == null || this.exibirBotaoAcao.length <= 0) {
            return true;
        }

        if (botao < 0) {
            return false;
        }

        return this.exibirBotaoAcao.some(x => x == botao);
    }

    onFileSelect(inputFile: any): void {


        for (var i = 0; i < inputFile.files.length; i++) {
            let file = inputFile.files.item(i);
            let f = this.getFileModel(file);

            if (this.ValidarFile(f)) {
                const reader = new FileReader();
                reader.onerror = this.readerOnError(f);
                reader.onprogress = this.readerOnProgress(f);
                reader.onload = this.readerOnLoad(f);
                reader.onloadstart = this.readerOnLoadStart(f);
                reader.onloadend = this.readerOnLoadEnd(f);
                reader.readAsDataURL(file);
            }
        }

        inputFile.value = null;
        inputFile.files = null;

        this.loadGrid();
    }

    readerOnError(file: FgvInputFile_File) {

        return (e: any) => {

            switch (e.target.error.code) {
                case e.target.error.NOT_FOUND_ERR:
                    this.message.error('Arquivo "' + file.name + '" não encontrado.');
                    break;
                case e.target.error.NOT_READABLE_ERR:
                    this.message.error('Arquivo "' + file.name + '" não legível.');
                    break;
                case e.target.error.ABORT_ERR:
                    break;    // no operation
                default:
                    this.message.error('Ocorreu um erro ao ler o arquivo "' + file.name + '".');
                    break;
            }
        }
    }

    readerOnProgress(file: FgvInputFile_File) {

        return (e: any) => {
            if (e.lengthComputable) {
                file.readerProgress = Math.round((e.loaded / e.total) * 100);
            }
        }
    }

    readerOnLoad(file: FgvInputFile_File) {

        return (e: any) => {
            
            file.srcImage = e.target.result;
            file.fileBytes = e.target.result.split('base64,')[1];
            file.bytesInBrowser = true;

            this.addArquivo(file);
        }
    }

    readerOnLoadStart(file: FgvInputFile_File) {

        return (e: any) => {

            this.showLoading();
        }
    }

    readerOnLoadEnd(file: FgvInputFile_File) {

        return (e: any) => {

            this.hideLoading();
        }
    }

    getFileModel(file: any): FgvInputFile_File {

        let f = new FgvInputFile_File();
        f.lastModified = file.lastModified;
        f.lastModifiedDate = file.lastModifiedDate;
        f.name = file.name;
        f.size = file.size;
        f.type = file.type;
        f.readerProgress = 0;

        let s = file.name.split(".");
        f.extension = s[s.length - 1];
        f.extension = '.' + f.extension.toLowerCase();

        return f;
    }

    private ValidarFile(file: FgvInputFile_File): boolean {

        let maxMbTotal = file.size / 1024 / 1024;

        if (this.maxMbFile > 0 && maxMbTotal > this.maxMbFile) {
            this.message.error('Tamanho máximo de arquivo excedido.');
            return false;
        }

        this.arquivos.forEach(x => maxMbTotal += (x.size / 1024 / 1024));

        if (this.maxMbFileAll > 0 && maxMbTotal > this.maxMbFileAll) {
            this.message.error('Total máximo de arquivo excedido.');
            return false;
        }

        let s = file.name.split(".");
        let ext = s[s.length - 1];
        ext = '.' + ext.toLowerCase();
        if (this.formatosPermitidos != null && this.formatosPermitidos.length > 0 && !this.formatosPermitidos.some(x => ext == x.toLowerCase())) {
            this.message.error('Extensão "' + ext + '" não é permitida.');
            return false;
        }

        return true;
    }

    addArquivo(file: FgvInputFile_File): void {

        this.arquivos.push(file);

        if (this.onAddArquivo != null) {
            this.onAddArquivo.emit(file);
        }
    }

    delArquivo(index: number): void {

        this.arquivos.splice(index, 1);

        if (this.onDelArquivo != null) {
            this.onDelArquivo.emit(index);
        }
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

    downloadArquivo(file: FgvInputFile_File): void {
        
        if (file.bytesInBrowser) {

            let bytes: Uint8Array;

            if (file.fileBytes != null && file.fileBytes.length > 0) {
                bytes = this.base64ToArrayBuffer(file.fileBytes);
            } else {
                bytes = this.base64ToArrayBuffer('');
            }

            this.gerarArquivo(bytes, file.name, file.type);

            return;
        }

        if (this.onDownloadArquivo != null) {
            this.onDownloadArquivo.emit(file);
        }
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

    delay(ms: number) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    public modalShow(file: FgvInputFile_File): void {
        this.modalFile = file;
        this.modal.show();
    }

    public modalClose(): void {
        this.modal.hide();
    }
}
