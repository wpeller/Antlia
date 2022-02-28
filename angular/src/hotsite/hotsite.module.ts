import { FgvTableActionContentModule } from './../app/shared/component/fgv-table-action-content/fgv-table-action-content.module';
import { FgvTableActionButtonModule } from './../app/shared/component/fgv-table-action-button/fgv-table-action-button.module';
import { DocumentoDownloadModule } from 'hotsite/documento-download/documento-download.module';

import { FgvInputEmailModule } from './../app/shared/component/fgv-input-email/fgv-input-email.module';
import { NgModule } from "@angular/core";
import { FgvInputPasswordModule } from "@app/shared/component/fgv-input-password/fgv-input-password.module";
import { FgvInputTextModule } from "@app/shared/component/fgv-input-text/fgv-input-text.module";
import { HotsiteRoutingModule } from "./hotsite-routing.module";
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvCardModule } from "ngx-siga2-componentes";
import { UtilsModule } from "@shared/utils/utils.module";
import { TableModule } from "primeng/table";
import { PaginatorModule } from "primeng/paginator";
import { CheckboxModule } from "primeng/primeng";
import { AccordionModule } from 'ngx-bootstrap';

import { HotsiteLoginComponent } from './acesso/hotsite-login/hotsite-login.component';
import { HomeAdmComponent } from './homeAdm/homeAdm.component';
import { RedefinirSenhaComponent } from './acesso/redefinir-senha/redefinir-senha/redefinir-senha.component';
import { HomeAdmModule } from './homeAdm/home-adm.module';
import { HotSiteComponent } from './hotsite.component';
import { MatchesTurmaPipe } from './matchesTurma.pipe';
import { GerenciarInscritosComponent } from './gerenciar-inscritos/gerenciar-inscritos.component';
import { HotSitePublicadoModule } from './hotsite_publicado/hotsite-publicado.module';
import { MenuComponent } from './menu/menu.component';
import { FooterAdmComponent } from './footer-adm/footer-adm.component';
import { FgvComponentModule } from '@app/shared/component/FgvComponentModule/fgv-components.module';


@NgModule({
    imports:
        [
            HotsiteRoutingModule,
            TableModule,
            PaginatorModule,
            FgvInputPasswordModule,
            FgvInputTextModule,
            FgvInputEmailModule,
            FgvCardModule,
            CommonModule,
            FormsModule,
            ReactiveFormsModule,
            UtilsModule,
            CheckboxModule,
            HomeAdmModule,
            DocumentoDownloadModule,
            AccordionModule.forRoot(),
            FgvTableActionButtonModule,
            FgvTableActionContentModule,
            FgvComponentModule


        ],
    declarations:
        [
            RedefinirSenhaComponent,
            HotsiteLoginComponent,
            HomeAdmComponent,
            HotSiteComponent,
            GerenciarInscritosComponent,
            MatchesTurmaPipe,
            MenuComponent,
            FooterAdmComponent
        ],
    exports: [],
    providers: []
})

export class HotsiteModule { }
