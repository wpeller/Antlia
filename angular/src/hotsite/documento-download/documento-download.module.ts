import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvCarrousselModule } from '@app/shared/component/fgv-carroussel/fgv-carroussel.module';
import { FgvMenuHorizontalModule } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.module';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { DocumentoDownloadComponent } from './documento-download.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvCarrousselModule,
        FgvMenuHorizontalModule
    ],
    declarations: [DocumentoDownloadComponent],
    exports: [DocumentoDownloadComponent],
    bootstrap: [DocumentoDownloadComponent],
    providers: [HotSiteInCompanyServiceProxy]
})
export class DocumentoDownloadModule { }
