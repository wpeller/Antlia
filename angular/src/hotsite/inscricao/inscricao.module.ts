import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvButtonModule } from '@app/shared/component/fgv-button/fgv-button.module';
import { FgvInputSelectModule } from '@app/shared/component/fgv-input-select/fgv-input-select.module';
import { FgvInputTextModule } from '@app/shared/component/fgv-input-text/fgv-input-text.module';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { HotSiteMasterPageModule } from 'hotsite/hotsite-master-page/hotsite-master-page.module';
import { InscricaoComponent } from './inscricao.component';
import { FgvInputEmailModule } from '@app/shared/component/fgv-input-email/fgv-input-email.module';
import { FgvInputCpfModule } from '@app/shared/component/fgv-input-cpf/fgv-input-cpf.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvInputTextModule,
        FgvInputSelectModule,
        FgvButtonModule,
        FgvInputEmailModule,
        FgvInputCpfModule,
        HotSiteMasterPageModule
    ],
    declarations: [InscricaoComponent],
    exports: [InscricaoComponent],
    bootstrap: [InscricaoComponent],
    providers: [HotSiteInCompanyServiceProxy]
})
export class InscricaoModule { }
