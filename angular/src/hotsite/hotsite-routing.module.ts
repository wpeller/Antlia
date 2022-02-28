
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RedefinirSenhaComponent } from "./acesso/redefinir-senha/redefinir-senha/redefinir-senha.component";
import { GerenciarInscritosComponent } from './gerenciar-inscritos/gerenciar-inscritos.component';
import { HotsiteLoginComponent } from './acesso/hotsite-login/hotsite-login.component';
import { HomeAdmComponent } from './homeAdm/homeAdm.component';
import { HotSiteComponent } from "./hotsite.component";
import { HotSitePublicadoComponent } from "./hotsite_publicado/hotsite-publicado.component";
import { DocumentoDownloadComponent } from "./documento-download/documento-download.component";


@NgModule({
    imports: [
        RouterModule.forChild([
            // { path: '', component:HotsiteLoginComponent},
            { path: 'redefinir-senha', component: RedefinirSenhaComponent },
            { path: 'gerenciar-inscritos', component: GerenciarInscritosComponent },
            { path: ':nomeHotSite/gerenciar-inscritos', component: GerenciarInscritosComponent },
            { path: ':nomeHotSite/admin', component: HotsiteLoginComponent },
            { path: 'home', component: HotSiteComponent },
            {
                path: 'documento/download/:token',
                component: DocumentoDownloadComponent,
                canActivate: [],
                children: []
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class HotsiteRoutingModule { }
