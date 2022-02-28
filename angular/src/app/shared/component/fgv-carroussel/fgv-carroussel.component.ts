import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
    selector: 'fgv-carroussel',
    templateUrl: './fgv-carroussel.component.html',
    styleUrls: ['./fgv-carroussel.component.css']
})
export class FgvCarrousselComponent implements OnInit, AfterViewInit {
    @ViewChild('divPrincipal') divPrincipal: ElementRef;
    @Output() imagemOnClick: EventEmitter<FgvCarrousselImagem> = new EventEmitter<FgvCarrousselImagem>();
    @Input() lista: FgvCarrousselImagem[] = [];
    @Input() paginador: FgvCarrousselPaginador = new FgvCarrousselPaginador();

    private index: number = 0;
    private contador: number = 0;

    constructor() {
    }

    ngOnInit() {
        this.carregarListaImagem(this.lista);
    }

    ngAfterViewInit(): void {
        setInterval(() => { this.rolagem(); }, 1000);
    }

    clearImagem(): void {
        this.lista = [];
    }

    addImagem(imagem: FgvCarrousselImagem): void {
        if (imagem == null) {
            return;
        }

        if (this.lista == null) {
            this.lista = [];
        }

        this.lista.push(imagem);
        this.carregarListaImagem(this.lista);
    }

    carregarListaImagem(lista: FgvCarrousselImagem[]): void {

        this.lista = lista;

        if (this.lista == null || this.lista.length <= 0) {
            return;
        }

        this.index = 0;
        this.activeImagem(this.index);

        this.carregarPaginador();
        this.activePaginador(this.index);
    }

    activeImagem(index: number): void {
        for (var i = 0; i < this.lista.length; i++) {
            if (i == index) {
                this.lista[i].classe = 'carousel-item active';
            } else {
                this.lista[i].classe = 'carousel-item';
            }
        }
    }

    carregarPaginador(): void {
        this.paginador.visible = true;

        if (this.lista == null || this.lista.length <= 1) {
            this.paginador.visible = false;
            return;
        }

        this.paginador.clear();

        for (var i = 0; i < this.lista.length; i++) {
            let item = new FgvCarrousselPaginadorItem();
            item.index = i;
            item.titulo = this.lista[i].titulo;

            this.paginador.add(item);
        }
    }

    activePaginador(index: number): void {
        for (var i = 0; i < this.paginador.itens.length; i++) {
            if (i == index) {
                this.paginador.itens[i].classe = 'active';
            } else {
                this.paginador.itens[i].classe = '';
            }
        }
    }

    rolagem(): void {

        if (this.lista == null || this.lista.length <= 1) {
            return;
        }

        this.contador++;

        if (this.contador >= 5) {
            this.contador = 0;
            this.next();
        }
    }

    next() {
        this.contador = 0;
        var atual = this.lista[this.index];

        this.index++;

        if (this.index >= this.lista.length) {
            this.index = 0;
        }

        var next = this.lista[this.index];

        this.divPrincipal.nativeElement.style.height = this.divPrincipal.nativeElement.offsetHeight + 'px';
        next.classe = 'carousel-item carousel-item-next carousel-item-right';
        atual.style = { 'position': 'absolute' };

        setTimeout(() => {
            atual.classe = 'carousel-item active carousel-item-left';
            next.classe = 'carousel-item active';

            setTimeout(() => {
                atual.classe = 'carousel-item';

                setTimeout(() => {
                    atual.style = { 'position': '' };
                    this.divPrincipal.nativeElement.style.height = '';
                }, 1);
            }, 800);
        }, 1);

        this.activePaginador(this.index);
    }

    previous() {
        this.contador = 0;
        var atual = this.lista[this.index];

        this.index--;

        if (this.index < 0) {
            this.index = this.lista.length - 1;
        }

        var next = this.lista[this.index];

        this.divPrincipal.nativeElement.style.height = this.divPrincipal.nativeElement.offsetHeight + 'px';
        next.classe = 'carousel-item carousel-item-prev carousel-item-left';
        atual.style = { 'position': 'absolute' };

        setTimeout(() => {
            atual.classe = 'carousel-item active carousel-item-right';
            next.classe = 'carousel-item active';

            setTimeout(() => {
                atual.classe = 'carousel-item';

                setTimeout(() => {
                    atual.style = { 'position': '' };
                    this.divPrincipal.nativeElement.style.height = '';
                }, 1);
            }, 800);
        }, 1);

        this.activePaginador(this.index);
    }

    selecionar(index: number) {

        if (index == this.index) {
            return;
        }

        this.contador = 0;

        var atual = this.lista[this.index];

        this.index = index;

        if (this.index >= this.lista.length) {
            this.index = 0;
        }

        var next = this.lista[this.index];

        this.divPrincipal.nativeElement.style.height = this.divPrincipal.nativeElement.offsetHeight + 'px';
        next.classe = 'carousel-item carousel-item-next carousel-item-right';
        atual.style = { 'position': 'absolute' };

        setTimeout(() => {
            atual.classe = 'carousel-item active carousel-item-left';
            next.classe = 'carousel-item active';

            setTimeout(() => {
                atual.classe = 'carousel-item';

                setTimeout(() => {
                    atual.style = { 'position': '' };
                    this.divPrincipal.nativeElement.style.height = '';
                }, 1);
            }, 800);
        }, 1);

        this.activePaginador(this.index);
    }

    imagemOnClickHandler(obj: FgvCarrousselImagem): void {
        this.imagemOnClick.emit(obj);
    }
}

export class FgvCarrousselImagem {
    identificador: string;
    titulo: string;
    url: string;
    src: string;
    classe: string;
    style: any;
}

export class FgvCarrousselPaginador implements OnInit {
    visible: boolean = true;
    itens: FgvCarrousselPaginadorItem[] = [];

    ngOnInit() {
        this.visible = this.itens != null && this.itens.length > 1;
    }

    add(item: FgvCarrousselPaginadorItem): void {
        if (this.itens == null) {
            this.itens = [];
        }

        this.itens.push(item);
    }

    clear(): void {
        this.itens = [];
    }
}

export class FgvCarrousselPaginadorItem {
    index: number;
    titulo: string;
    classe: string;
    style: any;
}
