import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { SelectItem } from 'primeng/primeng';

@Component({
    selector: 'fgv-list-box',
    templateUrl: './fgv-list-box.component.html',
    styleUrls: ['./fgv-list-box.component.css'],
})
export class FgvListBoxComponent implements OnInit {
    @ViewChild('origemListbox') origemListbox: ElementRef;
    @ViewChild('txtOrigem') txtOrigem: ElementRef;

    @Input() origemTitulo: string = 'Origem';
    @Input() origemReordernar: boolean = true;
    @Input() origemItens: SelectItem[] = [];
    private origemItensFiltrado: SelectItem[] = [];

    @Output() onToOrigem: EventEmitter<SelectItem[]> = new EventEmitter<SelectItem[]>();

    @ViewChild('destinoListBox') destinoListBox: ElementRef;
    @ViewChild('txtDestino') txtDestino: ElementRef;

    @Input() destinoTitulo: string = 'Destino';
    @Input() destinoReordernar: boolean = true;
    @Input() destinoItens: SelectItem[] = [];
    private destinoItensFiltrado: SelectItem[] = [];

    @Output() onToDestino: EventEmitter<SelectItem[]> = new EventEmitter<SelectItem[]>();

    @Input() exibirLoading: boolean = false;
    @Input() exibir: boolean = true;

    ngOnInit() {
        this.onLoad(this.origemItens, this.destinoItens);
    }

    onLoad(origem: SelectItem[], destino: SelectItem[]): void {
        if (origem == null) {
            origem = [];
        }

        if (destino == null) {
            destino = [];
        }

        this.origemItens = origem.filter(x => !destino.some(y => y.label == x.label));

        this.destinoItens = destino;

        this.ordenarOrigem();
        this.ordenarDestino();
    }

    ordenarOrigem(): void {
        this.origemItens = this.origemItens.sort((a, b) => a.label.toString().localeCompare(b.label));
    }

    ordenarDestino(): void {
        this.destinoItens = this.destinoItens.sort((a, b) => a.label.toString().localeCompare(b.label));
    }

    onChangeTextOrigem(text: string) {
        let _itens = this.origemItens.concat(this.origemItensFiltrado);

        if (text == null || text == '') {
            this.origemItens = _itens;
            this.origemItensFiltrado = [];
        } else {
            let _text = text.toUpperCase();
            this.origemItens = _itens.filter(x => x.label.toUpperCase().indexOf(_text) != -1);
            this.origemItensFiltrado = _itens.filter(x => !this.origemItens.some(y => y.label == x.label));
        }

        this.ordenarOrigem();
    }

    onChangeTextDestino(text: string) {
        let _itens = this.destinoItens.concat(this.destinoItensFiltrado);

        if (text == null || text == '') {
            this.destinoItens = _itens;
            this.destinoItensFiltrado = [];
        } else {
            let _text = text.toUpperCase();
            this.destinoItens = _itens.filter(x => x.label.toUpperCase().indexOf(_text) != -1);
            this.destinoItensFiltrado = _itens.filter(x => !this.destinoItens.some(y => y.label == x.label));
        }

        this.ordenarDestino();
    }

    toDestino(itens: SelectItem[]): void {
        if (itens == null) {
            return;
        }

        itens.forEach(item => { this.destinoItens.push(item); });

        if (this.destinoReordernar) {
            this.ordenarDestino();
        }

        this.origemItens = this.origemItens.filter(x => !itens.some(y => y.value == x.value));
        
        this.limparTxtDestino();

        this.onToDestino.emit(itens);
    }

    limparTxtDestino(): void {
        if (this.txtDestino == null || this.txtDestino.nativeElement == null) {
            return;
        }

        this.txtDestino.nativeElement.value = '';
        this.onChangeTextDestino('');
    }

    toOrigem(itens: SelectItem[]): void {
        if (itens == null) {
            return;
        }

        itens.forEach(item => { this.origemItens.push(item); });

        if (this.origemReordernar) {
            this.ordenarOrigem();
        }

        this.destinoItens = this.destinoItens.filter(x => !itens.some(y => y.value == x.value));
        
        this.limparTxtOrigem();

        this.onToOrigem.emit(itens);
    }

    limparTxtOrigem(): void {
        if (this.txtOrigem == null || this.txtOrigem.nativeElement == null) {
            return;
        }

        this.txtOrigem.nativeElement.value = '';
        this.onChangeTextOrigem('');
    }

    moveToDestino() {
        if (this.origemListbox == null || this.origemListbox.nativeElement == null || this.origemListbox.nativeElement.length <= 0) {
            return;
        }

        let item = this.origemListbox.nativeElement;
        let itensSelected: SelectItem[] = [];

        for (var i = 0; i < item.length; i++) {
            if (item[i].selected) {
                itensSelected.push(this.origemItens[i]);
            }
        }

        this.toDestino(itensSelected);
    }

    moveAllToDestino() {
        if (this.origemListbox == null || this.origemListbox.nativeElement == null || this.origemListbox.nativeElement.length <= 0) {
            return;
        }

        let item = this.origemListbox.nativeElement;
        let itens: SelectItem[] = [];

        for (var i = 0; i < item.length; i++) {
            itens.push(this.origemItens[i]);
        }

        this.toDestino(itens);
    }

    moveToOrigem() {
        if (this.destinoListBox == null || this.destinoListBox.nativeElement == null || this.destinoListBox.nativeElement.length <= 0) {
            return;
        }

        let item = this.destinoListBox.nativeElement;
        let itensSelected: SelectItem[] = [];

        for (var i = 0; i < item.length; i++) {
            if (item[i].selected) {
                itensSelected.push(this.destinoItens[i]);
            }
        }

        this.toOrigem(itensSelected);
    }

    moveAllToOrigem() {
        if (this.destinoListBox == null || this.destinoListBox.nativeElement == null || this.destinoListBox.nativeElement.length <= 0) {
            return;
        }

        let item = this.destinoListBox.nativeElement;
        let itens: SelectItem[] = [];

        for (var i = 0; i < item.length; i++) {
            itens.push(this.destinoItens[i]);
        }

        this.toOrigem(itens);
    }
}
