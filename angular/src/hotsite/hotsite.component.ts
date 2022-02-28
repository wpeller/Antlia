import { Component, Injector, OnInit, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppUiCustomizationService } from '@shared/common/ui/app-ui-customization.service';
import * as _ from 'lodash';
import * as moment from 'moment';
import { AuthhotsiteService } from './acesso/authhotsite.service';


@Component({
    templateUrl: './hotsite.component.html',
    styleUrls: [
        './hotsite.component.less'
    ],
    encapsulation: ViewEncapsulation.None
})

export class HotSiteComponent implements OnInit {

    mostrarMenu: boolean = false;
    idHotSite: number;
    usuarioAutenticado: boolean =false;

    constructor(private authService: AuthhotsiteService) { }

    ngOnInit() {
        this.usuarioAutenticado = this.authService.usuarioEstaAutenticado();
        console.log(this.usuarioAutenticado);

        this.authService.mostrarMenuEmitter.subscribe(
             mostrar => this.mostrarMenu = mostrar
         );
         console.log(this.mostrarMenu);

         this.mostrarMenu=this.usuarioAutenticado = this.authService.menuDeveSerExibido();
         console.log(this.mostrarMenu);

         this.idHotSite = 40;

      }

    // private viewContainerRef: ViewContainerRef;
    // tenantChangeDisabledRoutes: string[] = ['select-edition', 'buy', 'upgrade', 'extend', 'register-tenant'];

    // public constructor(
    //     injector: Injector,
    //     private _router: Router,
    //     viewContainerRef: ViewContainerRef
    // ) {
    //     super(injector);

    //     // We need this small hack in order to catch application root view container ref for modals
    //     this.viewContainerRef = viewContainerRef;
    // }

    // ngOnInit(): void {
    //     // this._loginService.init();
    //     // document.body.className = this._uiCustomizationService.getAccountModuleBodyClass();
    // }

    // showTenantChange(): boolean {
    //     if (!this._router.url) {
    //         return false;
    //     }

    //     if (_.filter(this.tenantChangeDisabledRoutes, route => this._router.url.indexOf('/account/' + route) >= 0).length) {
    //         return false;
    //     }

    //     return abp.multiTenancy.isEnabled && !this.supportsTenancyNameInUrl();
    // }

    // private supportsTenancyNameInUrl() {
    //     return (AppConsts.appBaseUrlFormat && AppConsts.appBaseUrlFormat.indexOf(AppConsts.tenancyNamePlaceHolderInUrl) >= 0);
    // }
}
