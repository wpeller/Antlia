import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
@Component({
    selector: 'fgv-button',
    templateUrl: './fgv-button.component.html',
    styleUrls: ['./fgv-button.component.css'],
})
export class FgvButtonComponent implements OnInit {
    @Input() iconClass: string = '';
    @Input() buttonClass: string = '';
    @Input() buttonDisabled: boolean = false;
    @Input() buttonText: string = '';
    @Input() visibleButtonText: boolean = true;
    @Input() buttonStyle: any;

    @Output() onClick: EventEmitter<any> = new EventEmitter<any>();

    constructor() {
    }

    ngOnInit() {

        let _text = this.buttonText == null ? '' : this.buttonText.toUpperCase();

        if (_text == 'BUSCAR') {
            this.getBuscar();
        } else if (_text == 'LIMPAR') {
            this.getLimpar();
        } else if (_text == 'NOVO') {
            this.getNovo();
        } else if (_text == 'VOLTAR') {
            this.getVoltar();
        } else if (_text == 'SALVAR') {
            this.getSalvar();
        } else if (_text == 'CANCELAR') {
            this.getCancelar();
        } else if (_text == 'CONFIRMAR') {
            this.getConfirmar();
        } else if (_text == 'INCLUIR') {
            this.getIncluir();
        } else if (_text == 'ADICIONAR') {
            this.getAdicionar();
        } else if (_text == 'COPIAR') {
            this.getCopiar();
        }
        else {
            this.getDefault();
        }
    }

    onClickHandler(): void {
        this.onClick.emit();
    }

    private getDefault(): void {
        if (this.buttonText != null && this.buttonText != '') {
            this.buttonText = this.visibleButtonText ? this.buttonText : '';
        }

        if (this.buttonClass == null || this.buttonClass == '') {
            this.buttonClass = 'fgv-button-css btn btn-primary';
        }
    }

    private getBuscar(): void {
        this.buttonText = this.visibleButtonText ? 'BUSCAR' : '';
        this.iconClass = 'fa fa-search';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getLimpar(): void {
        this.buttonText = this.visibleButtonText ? 'LIMPAR' : '';
        this.iconClass = 'fa fa-eraser';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getNovo(): void {
        this.buttonText = this.visibleButtonText ? 'NOVO' : '';
        this.iconClass = 'fa fa-plus';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getVoltar(): void {
        this.buttonText = this.visibleButtonText ? 'VOLTAR' : '';
        this.iconClass = 'fa fa-arrow-left';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getSalvar(): void {
        this.buttonText = this.visibleButtonText ? 'SALVAR' : '';
        this.iconClass = 'fa fa-save';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getCancelar(): void {
        this.buttonText = this.visibleButtonText ? 'CANCELAR' : '';
        this.iconClass = '';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getConfirmar(): void {
        this.buttonText = this.visibleButtonText ? 'CONFIRMAR' : '';
        this.iconClass = 'fa fa-check';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getIncluir(): void {
        this.buttonText = this.visibleButtonText ? 'INCLUIR' : '';
        this.iconClass = 'fa fa-plus';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getAdicionar(): void {
        this.buttonText = this.visibleButtonText ? 'ADICIONAR' : '';
        this.iconClass = 'fa fa-plus';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }

    private getCopiar(): void {
        this.buttonText = this.visibleButtonText ? 'COPIAR' : '';
        this.iconClass = 'fa fa-copy';
        this.buttonClass = 'fgv-button-css btn btn-primary';
    }
}
