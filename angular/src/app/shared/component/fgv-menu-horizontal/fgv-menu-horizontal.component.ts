import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'fgv-menu-horizontal',
    templateUrl: './fgv-menu-horizontal.component.html',
    styleUrls: ['./fgv-menu-horizontal.component.css']
})
export class FgvMenuHorizontalComponent implements OnInit {
    @ViewChild('divItemMenu') divItemMenu: ElementRef;
    @ViewChild('buttonCollapse') buttonCollapse: ElementRef;
    @Input() menus: FgvMenuHorizontalItemMenu[] = [];
    @Input() logos: FgvMenuHorizontalLogo[] = [];
    @Input() styleBarraMenu: any;
    @Output() menuOnClick: EventEmitter<FgvMenuHorizontalItemMenu> = new EventEmitter<FgvMenuHorizontalItemMenu>();
    @Output() logoOnClick: EventEmitter<FgvMenuHorizontalLogo> = new EventEmitter<FgvMenuHorizontalLogo>();
    exibirMenuOculto: boolean = false;

    get visible(): any {
        return (this.logos != null && this.logos.length > 0) || (this.menus != null && this.menus.length > 0);
    }

    constructor(private router: Router) {
    }

    ngOnInit() {
        this.carregarMenu(this.menus);
    }

    carregarMenu(menus: FgvMenuHorizontalItemMenu[]): void {
        this.menus = menus;
    }

    carregarLogo(logos: FgvMenuHorizontalLogo[]): void {
        this.logos = logos;
    }

    clearLogo(): void {
        this.logos = [];
    }

    addLogo(logo: FgvMenuHorizontalLogo): void {

        if (logo == null) {
            return;
        }

        if (this.logos == null) {
            this.logos = [];
        }

        this.logos.push(logo);
    }

    logoOnClickHandler(obj: FgvMenuHorizontalLogo): void {
        this.logoOnClick.emit(obj);
    }

    menuOnClickHandler(obj: FgvMenuHorizontalItemMenu): void {
        this.exibirOcultarMenu(this.buttonCollapse);
        this.menuOnClick.emit(obj);
    }

    buttonCollapseOnClickHandler(event: any) {
        this.exibirOcultarMenu(event.currentTarget);
    }

    exibirOcultarMenu(btn: any) {
        this.exibirMenuOculto = !this.exibirMenuOculto;

        if (this.exibirMenuOculto) {
            btn.className = 'navbar-toggler';
            btn.ariaExpanded = 'true';
            this.divItemMenu.nativeElement.className = 'navbar-collapse collapse show';
        } else {
            btn.className = 'navbar-toggler collapsed';
            btn.ariaExpanded = 'false';
            this.divItemMenu.nativeElement.className = 'navbar-collapse collapse';            
        }
    }
}

export class FgvMenuHorizontalItemMenu {
    identificador: any;
    titulo: string;
    url: string;
    subMenu: FgvMenuHorizontalItemMenu[] = [];
}

export class FgvMenuHorizontalLogo {
    identificador: any;
    titulo: string;
    url: string;
    src: string;
}
