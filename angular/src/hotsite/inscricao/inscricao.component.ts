import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { FgvCarrousselImagem } from '@app/shared/component/fgv-carroussel/fgv-carroussel.component';
import { FgvMenuHorizontalItemMenu, FgvMenuHorizontalLogo } from '@app/shared/component/fgv-menu-horizontal/fgv-menu-horizontal.component';
import { GenericItem } from '@app/shared/component/GenericItem';
import { GetCurrentLoginInformationsOutput, HotSiteInCompanyServiceProxy, InputDownloadObjectDto, InputInscrever, OutputInscrever } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'abp-ng2-module/dist/src/message/message.service';
import { copyFile } from 'fs';
import { HotSiteMasterPageComponent } from 'hotsite/hotsite-master-page/hotsite-master-page.component';
import { SelectItem } from 'primeng/api';
import { finalize } from 'rxjs/operators';
import { StringDecoder } from 'string_decoder';

@Component({
    selector: 'inscricao',
    templateUrl: './inscricao.component.html',
    styleUrls: ['./inscricao.component.css']
})
export class InscricaoComponent implements OnInit {
    @ViewChild('masterPage') masterPage: HotSiteMasterPageComponent;
    private message: MessageService;
    private loadingCount: number[] = [];
    private activatedRoute: ActivatedRoute;
    private router: Router;
    private _hotSiteInCompanyService: HotSiteInCompanyServiceProxy;
    formInscricao: FormGroup;
    formBuilder: FormBuilder;
    idHotSiteInCompany: number;
    turmas: SelectItem[] = [];
    buttonInscreverStyle: any;
    exibirFormulario: boolean;

    constructor(injector: Injector,private titleService: Title) {
        this.formBuilder = injector.get(FormBuilder);
        this.router = injector.get(Router);
        this.message = injector.get(MessageService);
        this.activatedRoute = injector.get(ActivatedRoute);
        this._hotSiteInCompanyService = injector.get(HotSiteInCompanyServiceProxy);
       
    }

    ngOnInit() {
        
        this.geraFormulario();
        let usuarioLogado: boolean = false;
        this.activatedRoute.params.subscribe(x => {
            this.getHotSiteInCompany(x.nomeHotSite, usuarioLogado);
        });
    }

    geraFormulario() {
        this.formInscricao = this.formBuilder.group({
            cpf: ['', Validators.required],
            email: ['', Validators.required],
            idTurma: ['', Validators.required],
        });
    }

    getHotSiteInCompany(nomeHotSite: string, usuarioLogado: boolean): void {

        if (nomeHotSite == null) {
            this.message.error('HotSite não informado.');
            return;
        }

        this.showLoading();

        this._hotSiteInCompanyService.buscarHotSiteInCompanyByNome(nomeHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x == null || x.id == null) {
                    this.message.error('HotSite não encontrado.');
                    this.exibirFormulario = false;
                }
                else {
                    if (!x.publicado || x.excluido) {
                        this.router.navigateByUrl('preview/inscricao/' + x.nomeHotSite);
                    }
                    else {
                        this.exibirFormulario = true;
                        this.idHotSiteInCompany = x.id;
                        this.carregarconfiguracao(x.id);
                        this.carregarMenu(x.id, x.nomeHotSite, usuarioLogado);
                        this.carregarCarroussel(x.id);
                        this.carregarLogo(x.id);
                        this.carregarTurmas(x.id);
                        
                    }
                }
            });
    }

    carregarconfiguracao(idHotSite: number): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPublicadoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x != null) {
                    this.masterPage.menu.styleBarraMenu = { 'background-color': x.corBarraMenu };
                    this.masterPage.styleTitulo = { 'color': x.corTitulo };
                    this.masterPage.styleFundo = { 'background-color': x.corFundo };
                    this.masterPage.setBackgroundColor(x.corFundo);
                    this.buttonInscreverStyle = { 'background-color': x.corBarraMenu, 'border-color': x.corBarraMenu };
                }
            });
    }

    carregarCarroussel(idHotSite: number): void {
        this.masterPage.clearImagemCarroussel();

        this.showLoading();

        this._hotSiteInCompanyService.buscarCarrosselPublicadoPorIdHotSite(idHotSite)
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

    carregarMenu(idHotSite: number, nomeHotSite: string, usuarioLogado: boolean): void {
        this.showLoading();

        this._hotSiteInCompanyService.buscarMenuPublicadoPorIdHotSite(idHotSite, usuarioLogado)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {

                let menus = x.sort((a, b) => a.ordem.toString().localeCompare(b.ordem.toString()))
                    .map(y => {
                        if (this.router.url.indexOf(y.rota) != -1) {
                            this.masterPage.titulo = y.titulo;
                            this.titleService.setTitle(y.titulo);
                        }

                        let url = '/hotsite/' + nomeHotSite;

                        let m = new FgvMenuHorizontalItemMenu();
                        m.identificador = y.id;
                        m.titulo = y.descricao
                        m.url = y.rota == null || y.rota == '' ? url + '/' + y.id : y.rota;

                        m.subMenu = y.subMenus.map(z => {
                            let s = new FgvMenuHorizontalItemMenu();
                            s.identificador = z.id;
                            s.titulo = z.descricao;
                            s.url = z.rota == null || z.rota == '' ? url + '/' + z.id : z.rota;

                            return s;
                        });

                        return m;
                    });

                this.masterPage.carregarMenu(menus);
            });
    }

    carregarLogo(idHotSite: number): void {
        this.masterPage.clearLogo();

        this.showLoading();

        this._hotSiteInCompanyService.buscarConfiguracaoPublicadoPorIdHotSite(idHotSite)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                this.addLogo(x.logoFGV, 'FGV', '');
                this.addLogo(x.logoEmpresa1, '', '');
                this.addLogo(x.logoEmpresa2, '', '');
            });
    }

    carregarTurmas(idHotSite: number): void {
        this.turmas = [];

        let cpfPassaporte = this.formInscricao.controls.cpf.value;


        this.showLoading();

        this._hotSiteInCompanyService.buscarTurmaPorIdHotSite(idHotSite,cpfPassaporte)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {             

                if (x.sucesso == false){
                    this.message.error(x.mensagem );
                    this.turmas = [];
                    return;
                }

                if (x.item != null) {
                    x.item.forEach(y => this.turmas.push(new GenericItem(y.getTurmaCurso, y.codigoTurma)));
                }
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
        if (obj == null || obj.url == null || obj.url == '') {
            return;
        }

        if (obj.url.indexOf('https://') != -1 || obj.url.indexOf('http://') != -1) {
            window.location.href = obj.url;
        } else {
            this.router.navigateByUrl(obj.url);
        }
    }

    buttonInscreverOnClick(): void {
        if (this.formInscricao.invalid) {
            this.validarCampos(this.formInscricao);
            return;
        }

        let input: InputInscrever = new InputInscrever();
        input.codigoTurma = this.formInscricao.controls.idTurma.value;
        input.cpf = this.formInscricao.controls.cpf.value;
        input.email = this.formInscricao.controls.email.value;
        input.idHotSiteInCompany = this.idHotSiteInCompany;

        this.showLoading();

        this._hotSiteInCompanyService.inscrever(input)
            .pipe(finalize(() => { this.hideLoading(); }))
            .subscribe(x => {
                if (x == null) {
                    this.message.error("Erro ao tentar registrar inscrição.");
                } else if (!x.sucesso) {
                    this.message.error(x.mensagem);
                } else {
                    let url = x.item.redirectTo + '?o=' + x.item.idOferta + '&op=' + x.item.idOpcaoOferta;
                    this.redirectPost(url, x.item );
                }
            });
    }

    private redirectPost(url: string, candidato: OutputInscrever): void {
        const myform = document.createElement('form');
        myform.method = 'POST';
        myform.action = url;
        myform.target = "_blank";
        myform.style.display = 'none';
        //myform.append('Content-Type', 'application/x-www-form-urlencoded');
        //myform.append('Accept', 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8');

        const hddCpf = document.createElement('input');
        hddCpf.id = 'cpfaluno';
        hddCpf.name = 'cpfaluno';
        hddCpf.type = 'hidden';
        hddCpf.value = candidato.cpf;
        myform.appendChild(hddCpf);

        const hddEmail = document.createElement('input');
        hddEmail.id = 'emailaluno';
        hddEmail.name = 'emailaluno';
        hddEmail.type = 'hidden';
        hddEmail.value = candidato.email;
        myform.appendChild(hddEmail);

        const hddTelefone = document.createElement('input');
        hddTelefone.id = 'Telefonealuno';
        hddTelefone.name = 'Telefonealuno';
        hddTelefone.type = 'hidden';
        hddTelefone.value = candidato.telefone;
        myform.appendChild(hddTelefone);

        const hddDDDTelefone = document.createElement('input');
        hddDDDTelefone.id = 'DDDTelefone';
        hddDDDTelefone.name = 'DDDTelefone';
        hddDDDTelefone.type = 'hidden';
        hddDDDTelefone.value = candidato.dddTelefone;
        myform.appendChild(hddDDDTelefone);


        const hddNome = document.createElement('input');
        hddNome.id = 'Nomealuno';
        hddNome.name = 'Nomealuno';
        hddNome.type = 'hidden';
        hddNome.value = candidato.nomeCandidato;
        myform.appendChild(hddNome);

        const hddDtNascimento = document.createElement('input');
        hddDtNascimento.id = 'DtNascimento';
        hddDtNascimento.name = 'DtNascimento';
        hddDtNascimento.type = 'hidden';
        hddDtNascimento.value = candidato.dataNascimento;
        myform.appendChild(hddDtNascimento);

        document.body.appendChild(myform);
        myform.submit();
    }

    private validarCampos(formulario: FormGroup) {
        Object.keys(formulario.controls).forEach((campo) => {
            const control = formulario.get(campo);
            if (control instanceof FormControl) {
                control.markAsTouched({ onlySelf: true });
            } else if (control instanceof FormGroup) {
                this.validarCampos(control);
            }
        });
    }

    txtCpfChange(): void {
        if (this.formInscricao.controls.cpf.valid == true){
            this.carregarTurmas(this.idHotSiteInCompany);
        }       

    }
}
