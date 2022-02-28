import * as _ from 'lodash';
import { AbpMultiTenancyService } from '@abp/multi-tenancy/abp-multi-tenancy.service';
import { AbpSessionService } from '@abp/session/abp-session.service';
import {
    Component,
    ElementRef,
    Injector,
    OnInit,
    ViewChild,
    ViewEncapsulation
} from '@angular/core';
import { AppAuthService } from '@app/shared/common/auth/app-auth.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { AppNavigationService } from './nav/app-navigation.service';
import {
    ChangeUserLanguageDto,
    LinkedUserDto,
    NavigationDto,
    PapelDto,
    ProfileServiceProxy,
    UserLinkServiceProxy
} from '@shared/service-proxies/service-proxies';
import { ImpersonationService } from '@app/admin/users/impersonation.service';
import { LinkedAccountService } from '@app/shared/layout/linked-account.service';
import { NavegacaoService } from '../services/navegacao.service';
import { PapelService } from '../services/papel.service';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';

@Component({
    templateUrl: './topbar.component.html',
    selector: 'topbar',
    encapsulation: ViewEncapsulation.None
})
export class TopBarComponent extends AppComponentBase implements OnInit {

    languages: abp.localization.ILanguageInfo[];
    currentLanguage: abp.localization.ILanguageInfo;
    isImpersonatedLogin = false;
    isMultiTenancyEnabled = false;
    shownLoginName = '';
    tenancyName = '';
    userName = '';
    profilePicture = AppConsts.appBaseUrl + '/assets/common/images/default-profile-picture.png';
    defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/app-logo-on-' + this.currentTheme.baseSettings.menu.asideSkin + '.svg';
    recentlyLinkedUsers: LinkedUserDto[];
    unreadChatMessageCount = 0;
    remoteServiceBaseUrl: string = AppConsts.remoteServiceBaseUrl;
    chatConnected = false;

    public papeis: PapelDto[] = [];
    public papeisAux: PapelDto[] = [];
    public papelAtual: PapelDto = new PapelDto();
    public papelTemp: PapelDto[] = [];

    public papelPesquisa: PapelDto[] = [];
    public menuPesquisa: NavigationDto[] = [];
    private menuOriginal: NavigationDto[] = [];

    public textoDePesquisa = '';
    public textoPesquisaParcial = '';
    public pesquisou = true;

    public dropdownPersistent = 1;

    @ViewChild('searchFilterText') searchFilterTextElement: ElementRef;
    @ViewChild('searchFilterTextParcial') searchFilterTextElementParcial: ElementRef;
    @ViewChild('dropdownPesquisaElement') dropdownPesquisaElement: ElementRef;

    constructor(
        injector: Injector,
        private _abpSessionService: AbpSessionService,
        private _abpMultiTenancyService: AbpMultiTenancyService,
        private _profileServiceProxy: ProfileServiceProxy,
        private _userLinkServiceProxy: UserLinkServiceProxy,
        private _authService: AppAuthService,
        private _impersonationService: ImpersonationService,
        private _linkedAccountService: LinkedAccountService,
        private _papelService: PapelService,
        private _usuarioService: UsuarioService,
        private _navigationService: AppNavigationService,
        public _navegacaoService: NavegacaoService,
        private router: Router
    ) {
        super(injector);
    }

    ngOnInit() {
        this.isMultiTenancyEnabled = this._abpMultiTenancyService.isEnabled;
        this.languages = _.filter(this.localization.languages, l => (l).isDisabled === false);

        this._papelService.obterPapeis().then(x => this.papeis = x);
        this._papelService.onTrocarDePapel.subscribe((papel: PapelDto) => {
            this.papelAtual = papel;
        });

        this.currentLanguage = this.localization.currentLanguage;
        this.isImpersonatedLogin = this._abpSessionService.impersonatorUserId > 0;

        this._navigationService.onMenuCarregado.subscribe(menu => this.menuOriginal = menu);

        this.setCurrentLoginInformations();
        this.getProfilePicture();
        this.getRecentlyLinkedUsers();

        this.registerToEvents();
    }

    public definirFocus() {
        setTimeout(() => this.searchFilterTextElement.nativeElement.focus(), 0);
        this.pesquisou = false;
        this.textoDePesquisa = '';
        this.papelPesquisa = this.papeis;
    }

    public definirFocusPerquisaPapeis() {
        setTimeout(() => this.searchFilterTextElementParcial.nativeElement.focus(), 0);
        this.pesquisou = false;
        this.textoPesquisaParcial = '';
        this.papeisAux = this.papeis;
    }

    public pesquisar() {
        this.papelPesquisa = this.papeis.filter(x => x.nome.toLowerCase().includes(this.textoDePesquisa.toLowerCase()));
        this.menuPesquisa = this.pesquisarMenu(this.menuOriginal, this.textoDePesquisa);
    }

    public pesquisarParcial() {
        if (this.papeisAux.length === 0) {
            this.papeisAux = this.papeis;
        }

        let pesquisa = this.textoPesquisaParcial;
        pesquisa = pesquisa.toLocaleLowerCase();

        this.papeisAux = this.papeis.filter(x => x.nome
            .replace('�', 'a')
            .replace('�', 'a')
            .replace('�', 'a')
            .replace('�', 'e')
            .replace('�', 'e')
            .replace('�', 'i')
            .replace('�', 'o')
            .replace('�', 'u')
            .toLocaleLowerCase().includes(pesquisa));
        this.menuPesquisa = this.pesquisarMenu(this.menuOriginal, pesquisa);
    }

    public pesquisarMenu(navigations: NavigationDto[], texto: string): NavigationDto[] {

        let retorno: NavigationDto[] = [];

        for (let nav of navigations) {
            if (nav.displayNamePtBr.toLowerCase().includes(texto.toLowerCase())) {
                retorno.push(nav);
            }
            if (nav.items.length > 0) {
                let retornoFilho = this.pesquisarMenu(nav.items, texto);
                if (retornoFilho.length > 0) {
                    for (let f of retornoFilho) {
                        retorno.push(f);
                    }
                }
            }
        }

        return retorno;
    }

    fecharPesquisa() {
        this.dropdownPesquisaElement.nativeElement.classList.remove('m-dropdown--open');
        this.dropdownPesquisaElement.nativeElement.classList.remove('m-dropdown__wrapper');
        this.textoPesquisaParcial = '';
        this.textoDePesquisa = '';
        this.pesquisou = true;
    }

    public navegarPara(item) {
        this._navegacaoService.navigateTo(item);
        this.fecharPesquisa();
        this.textoPesquisaParcial = '';
    }

    registerToEvents() {
        abp.event.on('profilePictureChanged', () => {
            this.getProfilePicture();
        });

        abp.event.on('app.chat.unreadMessageCountChanged', messageCount => {
            this.unreadChatMessageCount = messageCount;
        });

        abp.event.on('app.chat.connected', () => {
            this.chatConnected = true;
        });

        abp.event.on('app.getRecentlyLinkedUsers', () => {
            this.getRecentlyLinkedUsers();
        });

        abp.event.on('app.onMySettingsModalSaved', () => {
            this.onMySettingsModalSaved();
        });
    }

    onChangePapel(papel: PapelDto) {
        if (papel && papel.id) {
            this.papelAtual = this._papelService.trocarPapel(papel);
            this.router.navigate([`/app/${AppConsts.moduloAcesso}/home/dashboard`]);
            this.fecharPesquisa();
        }
    }

    changeLanguage(languageName: string): void {
        const input = new ChangeUserLanguageDto();
        input.languageName = languageName;

        this._profileServiceProxy.changeLanguage(input).subscribe(() => {
            abp.utils.setCookieValue(
                'Abp.Localization.CultureName',
                languageName,
                new Date(new Date().getTime() + 5 * 365 * 86400000), //5 year
                abp.appPath
            );

            window.location.reload();
        });
    }

    setCurrentLoginInformations(): void {
        this.shownLoginName = this._usuarioService.obterNomeUsuario();
        this.tenancyName = this.appSession.tenancyName;
        this.userName = this._usuarioService.obterUserName();
        AppConsts.usuarioLogado = this.userName;
    }

    getProfilePicture(): void {
        this._profileServiceProxy.getProfilePicture().subscribe(result => {
            if (result && result.profilePicture) {
                this.profilePicture = 'data:image/jpeg;base64,' + result.profilePicture;
            }
        });
    }

    getRecentlyLinkedUsers(): void {
        this._userLinkServiceProxy.getRecentlyUsedLinkedUsers().subscribe(result => {
            this.recentlyLinkedUsers = result.items;
        });
    }


    showLoginAttempts(): void {
        abp.event.trigger('app.show.loginAttemptsModal');
    }

    showLinkedAccounts(): void {
        abp.event.trigger('app.show.linkedAccountsModal');
    }

    changePassword(): void {
        abp.event.trigger('app.show.changePasswordModal');
    }

    changeProfilePicture(): void {
        abp.event.trigger('app.show.changeProfilePictureModal');
    }

    changeMySettings(): void {
        abp.event.trigger('app.show.mySettingsModal');
    }

    logout(): void {
        this._authService.logout();
    }

    AlterarSenha(): void {
        console.log(this.appSession.user.siga2UserName);

        if (this.appSession.user && !this.appSession.user.siga2UserName) {
            abp.event.trigger('app.show.changePasswordModal');
        } else if (this.appSession.user && this.appSession.user.siga2UserName) {
            this.router.navigate([`app/${AppConsts.moduloAcesso}/usuario/trocaSenha`]);
        }
    }

    onMySettingsModalSaved(): void {
        this.shownLoginName = this.appSession.getShownLoginName();
    }

    backToMyAccount(): void {
        this._impersonationService.backToImpersonator();
    }

    switchToLinkedUser(linkedUser: LinkedUserDto): void {
        this._linkedAccountService.switchToAccount(linkedUser.id, linkedUser.tenantId);
    }

    get chatEnabled(): boolean {
        return (!this._abpSessionService.tenantId || this.feature.isEnabled('App.ChatFeature'));
    }

    downloadCollectedData(): void {
        this._profileServiceProxy.prepareCollectedData().subscribe(() => {
            this.message.success(this.l('GdprDataPrepareStartedNotification'));
        });
    }
}
