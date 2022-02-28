import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { HotSiteMasterPageModule } from 'hotsite/hotsite-master-page/hotsite-master-page.module';
import { PreviewHotSiteComponent } from './preview-hotsite.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HotSiteMasterPageModule
    ],
    declarations: [PreviewHotSiteComponent],
    exports: [PreviewHotSiteComponent],
    bootstrap: [PreviewHotSiteComponent],
    providers: [HotSiteInCompanyServiceProxy]
})
export class PreviewHotSiteModule { }
