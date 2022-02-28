import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvCarrousselModule } from '@app/shared/component/fgv-carroussel/fgv-carroussel.module';
import { FgvMenuHorizontalModule } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.module';
import { FgvRodapeModule } from '@app/shared/component/fgv-rodape/fgv-rodape.module';
import { HotSiteMasterPageComponent } from './hotsite-master-page.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvCarrousselModule,
        FgvMenuHorizontalModule,
        FgvRodapeModule
    ],
    declarations: [HotSiteMasterPageComponent],
    exports: [HotSiteMasterPageComponent],
    bootstrap: [HotSiteMasterPageComponent],
    providers: []
})
export class HotSiteMasterPageModule { }
