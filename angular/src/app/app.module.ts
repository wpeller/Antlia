import { AbpModule } from '@abp/abp.module';
import * as ngCommon from '@angular/common';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { LinkAccountModalComponent } from '@app/shared/layout/link-account-modal.component';
import { LinkedAccountsModalComponent } from '@app/shared/layout/linked-accounts-modal.component';
import { LoginAttemptsModalComponent } from '@app/shared/layout/login-attempts-modal.component';
import { ChangePasswordModalComponent } from '@app/shared/layout/profile/change-password-modal.component';
import { ChangeProfilePictureModalComponent } from '@app/shared/layout/profile/change-profile-picture-modal.component';
import { MySettingsModalComponent } from '@app/shared/layout/profile/my-settings-modal.component';
import { SmsVerificationModalComponent } from '@app/shared/layout/profile/sms-verification-modal.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, TabsModule, TooltipModule, BsDropdownModule } from 'ngx-bootstrap';
import { FileUploadModule as PrimeNgFileUploadModule, PaginatorModule, ProgressBarModule, AutoCompleteModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { ImpersonationService } from './admin/users/impersonation.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './shared/layout/themes/default/default-layout.component';
import { Theme8LayoutComponent } from './shared/layout/themes/theme8/theme8-layout.component';
import { Theme2LayoutComponent } from './shared/layout/themes/theme2/theme2-layout.component';
import { Theme11LayoutComponent } from './shared/layout/themes/theme11/theme11-layout.component';
import { AppCommonModule } from './shared/common/app-common.module';
import { FooterComponent } from './shared/layout/footer.component';
import { LinkedAccountService } from './shared/layout/linked-account.service';
import { SideBarMenuComponent } from './shared/layout/nav/side-bar-menu.component';
import { TopBarMenuComponent } from './shared/layout/nav/top-bar-menu.component';
import { TopBarComponent } from './shared/layout/topbar.component';
import { DefaultBrandComponent } from './shared/layout/themes/default/default-brand.component';
import { Theme8BrandComponent } from './shared/layout/themes/theme8/theme8-brand.component';
import { Theme2BrandComponent } from './shared/layout/themes/theme2/theme2-brand.component';
import { Theme11BrandComponent } from './shared/layout/themes/theme11/theme11-brand.component';
import { UserNotificationHelper } from './shared/layout/notifications/UserNotificationHelper';
import { HeaderNotificationsComponent } from './shared/layout/notifications/header-notifications.component';
import { NotificationSettingsModalComponent } from './shared/layout/notifications/notification-settings-modal.component';
import { NotificationsComponent } from './shared/layout/notifications/notifications.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { TextMaskModule } from 'angular2-text-mask';
import { ImageCropperModule } from 'ngx-image-cropper';

// Metronic
import { PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG, PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    // suppressScrollX: true
};

import { CoreModule } from '@metronic/app/core/core.module';

import { LayoutConfigService } from '@metronic/app/core/services/layout-config.service';
import { UtilsService } from '@metronic/app/core/services/utils.service';
import { LayoutRefService } from '@metronic/app/core/services/layout/layout-ref.service';
import { NavegacaoService } from './shared/services/navegacao.service';
import { SupportDefaultComponent } from './shared/layout/support-default/support-default.component';
import { AuthService } from './shared/services/auth.service';
import { NgIdleKeepaliveModule } from '@ng-idle/keepalive';
import { DashboardComponent } from './dashboard.component';
import { PapelServicoServiceProxy, MenuServicoServiceProxy, UsuarioServicoServiceProxy, AutorizacaoServicoServiceProxy } from '@shared/service-proxies/service-proxies';
 

@NgModule({
    declarations: [
        AppComponent,
        DefaultLayoutComponent,
        Theme8LayoutComponent,
        Theme2LayoutComponent,
        Theme11LayoutComponent,
        HeaderNotificationsComponent,
        SideBarMenuComponent,
        TopBarMenuComponent,
        FooterComponent,
        LoginAttemptsModalComponent,
        LinkedAccountsModalComponent,
        LinkAccountModalComponent,
        ChangePasswordModalComponent,
        ChangeProfilePictureModalComponent,
        MySettingsModalComponent,
        SmsVerificationModalComponent,
        NotificationsComponent,
        NotificationSettingsModalComponent,
        TopBarComponent,
        DefaultBrandComponent,
        Theme8BrandComponent,
        Theme2BrandComponent,
        Theme11BrandComponent,
        SupportDefaultComponent,
        DashboardComponent
    ],
    imports: [
        ngCommon.CommonModule,
        FormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        TabsModule.forRoot(),
        BsDropdownModule.forRoot(),
        FileUploadModule,
        AbpModule,
        AppRoutingModule,
        UtilsModule,
        AppCommonModule.forRoot(),
        ServiceProxyModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        ProgressBarModule,
        PerfectScrollbarModule,
        CoreModule,
        NgxChartsModule,
        TextMaskModule,
        ImageCropperModule,
        NgIdleKeepaliveModule.forRoot(),
        AutoCompleteModule,
    ],
    providers: [
        { provide: LOCALE_ID, useValue: 'pt-BR' },
        AuthService,
        UsuarioServicoServiceProxy,
        AutorizacaoServicoServiceProxy,
        ImpersonationService,
        LinkedAccountService,
        UserNotificationHelper,
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
        },
        LayoutConfigService,
        UtilsService,
        LayoutRefService,
        NavegacaoService,
        PapelServicoServiceProxy,
        MenuServicoServiceProxy,
        UsuarioServicoServiceProxy
    ]
})
export class AppModule { }
