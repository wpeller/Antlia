
import { NgModule } from '@angular/core';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { HomeAdmComponent } from './homeAdm.component';
import { GerenciarInscritosComponent } from 'hotsite/gerenciar-inscritos/gerenciar-inscritos.component';
import { HotsiteLoginComponent } from 'hotsite/acesso/hotsite-login/hotsite-login.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: HomeAdmComponent,
                // children: [
                //      { path: 'hotsite/gerenciar-inscritos', component: GerenciarInscritosComponent }
                //  ]
            },
            //{path: 'home', component:HomeAdmComponent},
            //{ path: 'gerenciar-inscritos', component: GerenciarInscritosComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class HomeAdmRoutingModule {}
