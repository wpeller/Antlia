import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { DashboardComponent } from "./home/dashboard/dashboard.component";
import { TrocaSenhaUsuarioLogadoComponent } from "./troca-senha-usuario-logado/troca-senha-usuario-logado.component";
import { PaginaTesteComponent } from "./sso-teste/pagina-teste.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'home/dashboard', component: DashboardComponent },
                    { path: 'usuario/trocaSenha', component: TrocaSenhaUsuarioLogadoComponent},
                    { path: 'SSO/teste', component: PaginaTesteComponent}
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class BoundaryRoutingModule { }