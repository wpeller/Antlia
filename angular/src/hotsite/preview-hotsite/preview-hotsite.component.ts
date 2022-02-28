import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FgvCarrousselImagem } from '@app/shared/component/fgv-carroussel/fgv-carroussel.component';
import { FgvMenuHorizontalItemMenu, FgvMenuHorizontalLogo } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.component';
import { HotSiteInCompanyServiceProxy, InputDownloadObjectDto } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'abp-ng2-module/dist/src/message/message.service';
import { HotSiteMasterPageComponent } from 'hotsite/hotsite-master-page/hotsite-master-page.component';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'preview-hotsite',
    templateUrl: './preview-hotsite.component.html',
    styleUrls: ['./preview-hotsite.component.css']
})
export class PreviewHotSiteComponent implements OnInit {
    @ViewChild('masterPage') masterPage: HotSiteMasterPageComponent;
    private message: MessageService;
    private loadingCount: number[] = [];
    private activatedRoute: ActivatedRoute;
    private router: Router;
    private _hotSiteInCompanyService: HotSiteInCompanyServiceProxy;
    private menuSelecionado: boolean;

    constructor(injector: Injector) {
        this.router = injector.get(Router);
        this.message = injector.get(MessageService);
        this.activatedRoute = injector.get(ActivatedRoute);
        this._hotSiteInCompanyService = injector.get(HotSiteInCompanyServiceProxy);
    }

    ngOnInit() {
        let usuarioLogado: boolean = false;
        this.activatedRoute.params.subscribe(x => {

            if (x.idMenu != null && x.idMenu != '') {
                this.getMenu(x.idMenu, x.nomeHotSite, usuarioLogado);
            } else {
                this.getHotSiteInCompany(x.nomeHotSite, usuarioLogado);
            }
        });
    }

    getMenu(idMenu: number, nomeHotSite: string, usuarioLogado: boolean): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuPorId(idMenu)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(y => {
                if (y != null && y.rota != null && y.rota != '') {
                    this.redirectTo(y.rota);
                } else {
                    if (y != null) {
                        this.setConteudo(y.titulo, y.texto);
                    }

                    this.getHotSiteInCompany(nomeHotSite, usuarioLogado);
                }
            });
    }

    getHotSiteInCompany(nomeHotSite: string, usuarioLogado: boolean): void {

        if (nomeHotSite == null) {
            this.message.error('Hotsite não informado.');
            return;
        }

        this.showLoading();

        this._hotSiteInCompanyService.buscarHotSiteInCompanyByNome(nomeHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x == null || x.id == null) {
                    this.message.error('Hotsite não encontrado.');
                } else {
                    this.carregarconfiguracao(x.id);
                    this.carregarMenu(x.id, usuarioLogado);
                    this.carregarCarroussel(x.id);
                    this.carregarLogo(x.id);
                }
            });
    }

    carregarconfiguracao(idHotSite: number): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x != null) {
                    this.masterPage.menu.styleBarraMenu = { 'background-color': x.corBarraMenu };
                    this.masterPage.styleTitulo = { 'color': x.corTitulo };
                    this.masterPage.styleFundo = { 'background-color': x.corFundo };
                    this.masterPage.setBackgroundColor(x.corFundo);
                }
            });
    }

    carregarCarroussel(idHotSite: number): void {
        this.masterPage.clearImagemCarroussel();

        this.showLoading();

        this._hotSiteInCompanyService.buscarCarrosselPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                x.forEach(y => {
                    if (y != null && y.token != null && y.token != '') {
                        let input = new InputDownloadObjectDto();
                        input.token = y.token;

                        this.showLoading();

                        this._hotSiteInCompanyService.downloadBinaryObject(input)
                            .pipe(finalize(() => { this.hideLoading(); }))
                            .subscribe(z => {
                                if (z != null && z.bytes != null && z.bytes != '') {
                                    let i = new FgvCarrousselImagem();
                                    i.src = 'data:image/png;base64,' + z.bytes;
                                    i.titulo = y.nome;
                                    i.url = '';

                                    this.masterPage.addImagemCarroussel(i);
                                }
                            });
                    }
                });
            });
    }

    carregarMenu(idHotSite: number, usuarioLogado: boolean): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuPorIdHotSite(idHotSite, usuarioLogado)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                let menus = x.sort((a, b) => a.ordem.toString().localeCompare(b.ordem.toString()))
                    .map(y => {
                        if (!this.menuSelecionado) {
                            this.setConteudo(y.titulo, y.texto);
                        }

                        let m = new FgvMenuHorizontalItemMenu();
                        m.identificador = y.id;
                        m.titulo = y.descricao
                        m.url = y.rota;

                        m.subMenu = y.subMenus.map(z => {
                            let s = new FgvMenuHorizontalItemMenu();
                            s.identificador = z.id;
                            s.titulo = z.descricao;
                            s.url = y.rota;
                            return s;
                        });

                        return m;
                    });

                this.masterPage.carregarMenu(menus);
            });
    }

    setConteudo(titulo: string, texto: string): void {
        this.menuSelecionado = true;
        this.masterPage.titulo = titulo;
        this.masterPage.setConteudo(texto);
    }

    carregarLogo(idHotSite: number): void {
        this.masterPage.clearLogo();

        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                this.addLogo(x.logoFGV, 'FGV', '');
                this.addLogo(x.logoEmpresa1, '', '');
                this.addLogo(x.logoEmpresa2, '', '');
            });
    }

    addLogo(token: string, titulo: string, url: string): void {
        if (token == null || token == '') {
            return;
        }

        let input = new InputDownloadObjectDto();
        input.token = token;

        this.showLoading();

        this._hotSiteInCompanyService.downloadBinaryObject(input)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(y => {
                if (y != null && y.bytes != null && y.bytes != '') {
                    let logoFGV = new FgvMenuHorizontalLogo();
                    logoFGV.identificador = token;
                    logoFGV.titulo = titulo;
                    logoFGV.url = url;
                    logoFGV.src = 'data:image/png;base64,' + y.bytes;

                    this.masterPage.addLogo(logoFGV);
                }
            });
    }

    showLoading(): void {
        this.loadingCount.push(1);
        abp.ui.setBusy();
    }

    hideLoading(): void {
        this.loadingCount = this.loadingCount.slice(1)

        if (this.loadingCount.length <= 0) {
            abp.ui.clearBusy();
        }
    }

    menuOnClick(obj: FgvMenuHorizontalItemMenu): void {
        if (obj == null) {
            return;
        }

        if (obj.url != null && obj.url != '') {
            this.redirectTo(obj.url);
            return;
        }

        if (obj.identificador == null || obj.identificador == '') {
            return;
        }

        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuPorId(obj.identificador)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(y => {
                if (y != null) {
                    this.setConteudo(y.titulo, y.texto);
                }
            });
    }

    redirectTo(url: string): void {
        if (url == null || url == '') {
            return;
        }

        if (url.indexOf('https://') != -1 || url.indexOf('http://') != -1) {
            window.location.href = url;
        } else {
            this.router.navigateByUrl(url);
        }
    }
}
