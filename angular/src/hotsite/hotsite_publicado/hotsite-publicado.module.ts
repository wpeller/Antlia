import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { HotSiteMasterPageModule } from 'hotsite/hotsite-master-page/hotsite-master-page.module';
import { HotSitePublicadoComponent } from './hotsite-publicado.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HotSiteMasterPageModule
    ],
    declarations: [HotSitePublicadoComponent],
    exports: [HotSitePublicadoComponent],
    bootstrap: [HotSitePublicadoComponent],
    providers: [HotSiteInCompanyServiceProxy]
})
export class HotSitePublicadoModule { }
