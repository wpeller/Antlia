import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { FgvCarrousselComponent, FgvCarrousselImagem } from '@app/shared/component/fgv-carroussel/fgv-carroussel.component';
import { FgvMenuHorizontalComponent, FgvMenuHorizontalItemMenu, FgvMenuHorizontalLogo } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.component';
import { document } from 'ngx-bootstrap';

@Component({
    selector: 'hotsite-master-page',
    templateUrl: './hotsite-master-page.component.html',
    styleUrls: ['./hotsite-master-page.component.css']
})
export class HotSiteMasterPageComponent implements OnInit, AfterViewInit {
    @ViewChild('carroussel') carroussel: FgvCarrousselComponent;
    @ViewChild('menu') menu: FgvMenuHorizontalComponent;
    @ViewChild('divConteudo') divConteudo: ElementRef;

    @Output() menuOnClick: EventEmitter<FgvMenuHorizontalItemMenu> = new EventEmitter<FgvMenuHorizontalItemMenu>();
    @Output() logoOnClick: EventEmitter<FgvMenuHorizontalLogo> = new EventEmitter<FgvMenuHorizontalLogo>();

    @Input() titulo: string;
    @Input() styleTitulo: any;
    @Input() styleFundo: any;
    @Input() backgroundColor: string;

    styleDivConteudo: any;

    constructor(private titleService: Title) {
    }

    ngOnInit() {
        
    }

    ngAfterViewInit(): void {
        this.setBackgroundColor(this.backgroundColor);
    }

    setBackgroundColor(backgroundColor: string): void {
        if (backgroundColor == null || backgroundColor == '') {
            return;
        }

        this.backgroundColor = backgroundColor;
        document.body.style.setProperty("background-color", backgroundColor, "important");
    }

    clearImagemCarroussel(): void {
        this.carroussel.clearImagem();
    }

    addImagemCarroussel(imagem: FgvCarrousselImagem): void {
        this.carroussel.addImagem(imagem);
    }

    carregarMenu(menus: FgvMenuHorizontalItemMenu[]): void {
        this.menu.carregarMenu(menus);
    }

    setConteudo(texto: string): void {
        this.styleDivConteudo = texto != null && texto != '' ? { 'display': '' } : { 'display': 'none' };

        if (this.divConteudo != null && this.divConteudo.nativeElement != null) {
            this.divConteudo.nativeElement.innerHTML = texto;
            this.titleService.setTitle(this.titulo);
        }
    }

    carregarLogo(logo: FgvMenuHorizontalLogo[]): void {
        this.menu.carregarLogo(logo);
    }

    addLogo(logo: FgvMenuHorizontalLogo): void {
        this.menu.addLogo(logo);
    }

    clearLogo(): void {
        this.menu.clearLogo();
    }

    menuOnClickHandler(obj: FgvMenuHorizontalItemMenu): void {
        this.menuOnClick.emit(obj);
    }

    logoOnClickHandler(obj: FgvMenuHorizontalLogo): void {
        this.logoOnClick.emit(obj);
    }
}
