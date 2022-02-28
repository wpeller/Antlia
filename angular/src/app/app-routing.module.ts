import { AppComponent } from './app.component';
import { AppRouteGuard } from './shared/common/auth/auth-route-guard';
import { DashboardComponent } from './dashboard.component';
import {
    NavigationEnd,
    RouteConfigLoadEnd,
    RouteConfigLoadStart,
    Router,
    RouterModule
} from '@angular/router';
import { NgModule } from '@angular/core';
 

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                redirectTo: 'app',
                pathMatch: 'full',
            },
            {
                path: 'app',
                component: AppComponent,
                canActivate: [AppRouteGuard],
                children: [
                    {
                        path: '',
                        children: [
                            { path: '', redirectTo: '/app/dashboard', pathMatch: 'full' },
                        ],
                    },
                    {
                        path: 'main',
                        loadChildren: 'app/main/main.module#MainModule', //Lazy load main module
                        data: { preload: true }
                    },
                    {
                        path: 'boundary',
                        loadChildren: 'app/boundary/boundary.module#BoundaryModule',
                        data: { preload: true }
                    },
                    {
                        path: 'admin',
                        loadChildren: 'app/admin/admin.module#AdminModule', //Lazy load admin module
                        data: { preload: true },
                        canLoad: [AppRouteGuard]
                    },
                    { path: 'dashboard', component: DashboardComponent, canActivate: [AppRouteGuard] },
                    {
                        path: '**',
                        redirectTo: '/app/dashboard',
                    }
                ]
            },
            // {
            //     path: 'hotsite',
            //     loadChildren: 'hotsite/hotsite.module#HotsiteModule',
            //     runGuardsAndResolvers: 'always',
            //     data: { preload: true }
            // },
        ])
    ],
    exports: [RouterModule]
})

export class AppRoutingModule {
    constructor(
        private router: Router
    ) {
        router.events.subscribe((event) => {

            if (event instanceof RouteConfigLoadStart) {
                abp.ui.setBusy();
            }

            if (event instanceof RouteConfigLoadEnd) {
                abp.ui.clearBusy();
            }

            if (event instanceof NavigationEnd) {
                document.querySelector('meta[property=og\\:url').setAttribute('content', window.location.href);
            }
        });
    }
}
