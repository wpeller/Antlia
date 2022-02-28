import { HotSiteInCompany, InputInscricaoHabilitarDto, InscricaoDto, TokenAuthServiceProxy } from './../../shared/service-proxies/service-proxies';

import { AppComponentBase } from '@shared/common/app-component-base';
import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { GerenciarInscritosDto } from './dto/gerenciarDto';
import { InscritoDto } from './dto/inscritoDto';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthhotsiteService } from 'hotsite/acesso/authhotsite.service';
import { AppConsts } from '@shared/AppConsts';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';


@Component({
  selector: 'app-gerenciar-inscritos',
  templateUrl: './gerenciar-inscritos.component.html',
  styleUrls: ['./gerenciar-inscritos.component.css']
})
export class GerenciarInscritosComponent extends AppComponentBase implements OnInit {

    @ViewChild('dataTable') dataTable: Table;
    rowGroupMetadata: any;
    turmas: string[] = [];
    listaRetorno: GerenciarInscritosDto[] = [];
    //turmaInscritos: GerenciarInscritosDto[] = [];

    selectedInscritos: InscritoDto[]=[];
    idHotSite: number;
    nomeHotsite:string;
    tituloCard: string;
    tokenInvalido: boolean;
    defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/loginHotSite/logofgvInCompany.jpg';
    rotaSair: string;    

  constructor(
    injector:Injector,
    private hotsiteService: HotSiteInCompanyServiceProxy,
    private activatedRoute: ActivatedRoute,
    private authService: AuthhotsiteService,
    private router: Router,
    private _tokenAuthService: TokenAuthServiceProxy
  ) {
      super(injector);
  }

  ngOnInit() {

    

    abp.ui.setBusy();


    this.activatedRoute.queryParams.subscribe(params => {
        let token = params['Token'];
        //console.log(token);
        abp.ui.setBusy();
        if (token)
        {
          //console.log("encontrou token");
          this._tokenAuthService.externalTokenHotSite(token,"SSOGERENCIARINSCRITOS")
          .pipe(finalize(() => { abp.ui.clearBusy(); }))
          .subscribe(result => {
            //console.log(result);
            if (result.sucesso) {
                //console.log('Sucesso!');
                if (result.item.user == 'SIGA2')
                {
                    //console.log(result.item);
                    this.tokenInvalido = false;
                   // this.router.navigate(['/hotsite/' + this.nomeHotsite + '/gerenciar-inscrito']);
                    return;
                }
                else
                {
                    //console.log('tokenInvalido!');
                    this.tokenInvalido = true;
                    this.router.navigate(['/hotsite/' + this.nomeHotsite + '/admin']);
                    return;
                }
            } else {
              //console.log('tokenInvalido!');
              this.tokenInvalido = true;
              //abp.message.error(result.mensagem);
              this.router.navigate(['/hotsite/' + this.nomeHotsite + '/admin']);
              return;
            }
          });
        }
        else
        {
            //console.log("não encontrou token");
            this.tokenInvalido=true;
        }

      });


    this.activatedRoute.url.subscribe(url => {

        if (url[0].path.length > 0) {
            //console.log(this.tokenInvalido);
            this.nomeHotsite=  url[0].path;
            let exibirTela = false;
            if (this.tokenInvalido)
            {
                if (!this.authService.usuarioEstaAutenticado())
                {
                    abp.message.error('Usuário não está autenticado.');
                    this.router.navigate(['/hotsite/' + this.nomeHotsite + '/admin']);
                    exibirTela=false;
                    return;
                }
                exibirTela=true;
            }
            else
            {
                exibirTela=true;
            }

            if(exibirTela)
            {
                this.hotsiteService.buscarHotSiteInCompanyByNome(this.nomeHotsite)
                .pipe(finalize(()=>{abp.ui.clearBusy();}))
                .subscribe(result=>{
                  if(result.id){
                      if (result.excluido)
                      {
                        setTimeout(() => {
                            abp.message.error('Não é possível gerenciar inscritos de um Hotsite excluído.');
                            this.router.navigate(['/hotsite/' + this.nomeHotsite + '/admin']);
                            return;
                          }, 1000);
                      }
                      else
                      {
                        this.idHotSite = result.id;
                        this.tituloCard = "Gerenciar Inscritos - Hotsite:" + this.nomeHotsite;
                        this.rotaSair = '/hotsite/' + this.nomeHotsite + '/admin';
                        this.getTurmas(this.idHotSite);
                      }
                  }
                  else
                  {
                    this.idHotSite=0;
                    abp.message.error('Não foi encontrado Hotsite com o nome informado.');
                  }
                });
            }



        }
    });
  }

  getTurmas(idHotSite: number, turmaSelecionada?: string){
    this.listaRetorno=[];
    abp.ui.setBusy();
    this.hotsiteService.buscarInscritosPorHotSite(idHotSite)
    .pipe(finalize(()=> {abp.ui.clearBusy();}))
    .subscribe(result => {
      //console.log(result);
      if(result.length == 0 )
      {
        abp.message.error("Não foram encontrados alunos para o Hotsite informado.")
        return;
      }
      let _turmaGerenciarInscritos: GerenciarInscritosDto = new GerenciarInscritosDto;
      _turmaGerenciarInscritos.inscritos = [];

      result.forEach(t => {
        let turma = t.turma

        if (_turmaGerenciarInscritos.inscritos.length == 0){
            _turmaGerenciarInscritos.turma = turma ;
        }
        else{
            var existeTurma = _turmaGerenciarInscritos.inscritos.filter(
                    (x) => x.turma.includes(turma)
                ).length > 0;
            if (!existeTurma)
            {
              this.listaRetorno.push(_turmaGerenciarInscritos);
              _turmaGerenciarInscritos =  new GerenciarInscritosDto;
              _turmaGerenciarInscritos.inscritos = [];
              _turmaGerenciarInscritos.turma = turma ;
            }
            //console.log(existeTurma);
        }

        let inscrito = new InscritoDto();
        inscrito.turma = turma
        inscrito.cpf=t.cpf
        inscrito.nome= t.nomeInscrito;
        inscrito.situacao= t.situacaoCandidato;
        inscrito.idOferta = t.idOFerta;
        inscrito.idOpcaoOferta = t.idOpcaoOferta;
        _turmaGerenciarInscritos.inscritos.push(inscrito);
      });      

        this.listaRetorno.push(_turmaGerenciarInscritos);
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.totalRecordsCount = this.listaRetorno.length;
        this.primengTableHelper.records = this.listaRetorno;
        this.primengTableHelper.hideLoadingIndicator();

        if(turmaSelecionada != null){
          this.coordenarExibicao(turmaSelecionada);
        }

    });
  }



  isOpenChange(isOpened: boolean){  

    if (isOpened)
    {
        //desmarcar todos checkbox
        this.selectedInscritos = []; 
    }

    // var item = this.listaRetorno.findIndex(x=> x.isOpen == true);
    // if(item > -1){
    //   this.listaRetorno.find(x=> x.isOpen == true).isOpen = false;
    // }

    // console.log(this.listaRetorno);

 }

  habilitarInscritos(turma:string)
  {
    let input : InputInscricaoHabilitarDto = new InputInscricaoHabilitarDto;
    let i : InscricaoDto;

    
    input.inscritos=[];
    this.selectedInscritos.forEach((inscrito: any) =>{
        i = new InscricaoDto();
        i.nomeInscrito = inscrito.nome;
        i.cpf = inscrito.cpf;
        i.idOferta = inscrito.idOferta;
        i.idOpcaoOferta = inscrito.idOpcaoOferta;
        i.novaSituacaoCandidato = 'Habilitado';
        input.inscritos.push(i);

    });
    this.hotsiteService.habilitarInscritos(input)
      .pipe(finalize(()=> {abp.ui.clearBusy();}))
      .subscribe(result => {
          if (result.sucesso)
          {
            abp.message.success('Candidato(s) habilitado(s) com sucesso.');
            this.getTurmas(this.idHotSite, turma);
          }
          else
          {
            abp.message.error(result.mensagem);
          }
    });
  }

  removerHabilitacao(inscrito:any){ 

    if(inscrito.situacao != 'Habilitado')
    {
        abp.message.error('Somente inscritos com situação Habilitado podem ser desabilitados.');
        return;
    }

    this.message.confirm(
        this.l('Confirma remover a habilitação do candidato: <br/> {0}', inscrito.nome),
        ' ',
        (isConfirmed) => {
            if (isConfirmed) {
                abp.ui.setBusy();
                let _inscricao : InscricaoDto = new InscricaoDto();

                _inscricao.nomeInscrito = inscrito.nome;
                _inscricao.cpf = inscrito.cpf;
                _inscricao.idOferta = inscrito.idOferta;
                _inscricao.idOpcaoOferta = inscrito.idOpcaoOferta;
                // _inscricao.novaSituacaoCandidato = 'Pendente';
                _inscricao.novaSituacaoCandidato = 'Desabilitado';

                this.hotsiteService.mudarSituacaoCandidato(_inscricao)
                .pipe(finalize(()=> {abp.ui.clearBusy();}))
                .subscribe(result => {
                    if (result.sucesso)
                    {
                      abp.message.success('A situação do candidato foi modificada com sucesso.');
                      this.getTurmas(this.idHotSite, inscrito.turma);
                    }
                    else
                    {
                      abp.message.error(result.mensagem);
                    }
              });
            }
        },true
    );

  }

  inabilitar(inscrito:any){
    if(inscrito.situacao != 'Inscrito')
    {
        abp.message.error('Somente candidatos com situação Inscrito podem ser desabilitados.');
        return;
    }

    this.message.confirm(
        this.l('Confirma desabilitar o candidato: <br/> {0}', inscrito.nome),' '
       ,
        (isConfirmed) => {
            if (isConfirmed) {
                abp.ui.setBusy();
                let _inscricao : InscricaoDto = new InscricaoDto();

                _inscricao.nomeInscrito = inscrito.nome;
                _inscricao.cpf = inscrito.cpf;
                _inscricao.idOferta = inscrito.idOferta;
                _inscricao.idOpcaoOferta = inscrito.idOpcaoOferta;
                _inscricao.novaSituacaoCandidato = 'Desabilitado';

                this.hotsiteService.mudarSituacaoCandidato(_inscricao)
                .pipe(finalize(()=> {abp.ui.clearBusy();}))
                .subscribe(result => {
                    if (result.sucesso)
                    {
                      abp.message.success('A situação do candidato foi modificada com sucesso.');
                      this.getTurmas(this.idHotSite, inscrito.turma);
                    }
                    else
                    {
                      abp.message.error(result.mensagem);
                    }
              });
            }
        },true
    );
  }

  inscrever(inscrito:any){
    if(inscrito.situacao != 'Inabilitado')
    {
        abp.message.error('Somente candidatos com situação Inabilitado podem ser inscritos.');
        return;
    }

    this.message.confirm(
        this.l('Confirma inscrever o candidato: <br/> {0}', inscrito.nome),
        ' ',
        (isConfirmed) => {
            if (isConfirmed) {
                abp.ui.setBusy();
                let _inscricao : InscricaoDto = new InscricaoDto();

                _inscricao.nomeInscrito = inscrito.nome;
                _inscricao.cpf = inscrito.cpf;
                _inscricao.idOferta = inscrito.idOferta;
                _inscricao.idOpcaoOferta = inscrito.idOpcaoOferta;
                _inscricao.novaSituacaoCandidato = 'Inscrito';

                this.hotsiteService.mudarSituacaoCandidato(_inscricao)
                .pipe(finalize(()=> {abp.ui.clearBusy();}))
                .subscribe(result => {
                    if (result.sucesso)
                    {
                      abp.message.success('A situação do candidato foi modificada com sucesso.');
                      this.getTurmas(this.idHotSite, inscrito.turma);
                    }
                    else
                    {
                      abp.message.error(result.mensagem);
                    }
              });
            }
        },true
    );
  }



  totalizador(turma:any, tipoContador: string): number
  {
    var t = this.listaRetorno.find(x => x.turma == turma);
    let totalContador:number;
    switch (tipoContador) {
        case 'Candidatos':
            totalContador = t.inscritos.length;
            break;
        case 'Inscritos':
            totalContador = t.inscritos.filter(i=> i.situacao == 'Inscrito').length;
            break;
        case 'Habilitados':
            totalContador = t.inscritos.filter(i=> i.situacao == 'Habilitado').length;
            break;
        case 'Matriculados':
            totalContador = t.inscritos.filter(i=> i.situacao == 'Matriculado').length;
            break;
        case 'Pendentes':
            totalContador = t.inscritos.filter(i=> i.situacao == 'Pendente').length;
            break;
        case 'Desabilitados':
            totalContador = t.inscritos.filter(i=> i.situacao == 'Desabilitado').length;
            break;
    }
    return totalContador;
  }


  onRowSelect(event) {
    console.log(event.data);
 }

  onRowUnselect(event) {
    console.log(event.data);
  }

  selectRow(cbHeader, idTurma) {
    this.selectedInscritos = [];
    if (cbHeader.checked) {
        var listaCandidatos =  this.listaRetorno.find(t=> t.turma == idTurma)
                                   .inscritos.filter(i=> i.situacao == 'Pendente');
        if (listaCandidatos.length > 0)
        {
            this.selectedInscritos.push(...listaCandidatos);
        }
        else{
            cbHeader.checked = false;
        }

    }
    else {
        //desmarcado TODOS
        this.selectedInscritos = [];
    }
  }
  selectRowUnique(cbRow) {

    if (cbRow.checked)
    {
        cbRow.checked = false;
        this.selectedInscritos = [];
    }
  }

  isRowDisabled(data: any): boolean {
    return data.situacao==='Matriculado' || data.situacao==='Habilitado' ||  data.situacao==='Inscrito';
}

  habilitaAcoes(data: any): boolean{
      return data.situacao==='Habilitado' || data.situacao==='Inscrito';
  }

  onSort() {
    this.updateRowGroupMetaData();
}

  updateRowGroupMetaData() {
    this.rowGroupMetadata = {};
    if (this.listaRetorno) {
        for (let i = 0; i < this.listaRetorno.length; i++) {
            let rowData = this.listaRetorno[i];
            let turma = rowData.turma;
            if (i == 0) {
                this.rowGroupMetadata[turma] = { index: 0, size: 1 };
            }
            else {
                let previousRowData = this.listaRetorno[i - 1];
                let previousRowGroup = previousRowData.turma;
                if (turma === previousRowGroup)
                    this.rowGroupMetadata[turma].size++;
                else
                    this.rowGroupMetadata[turma] = { index: i, size: 1 };
            }
        }
    }
    }

    coordenarExibicao(turma:string){    
      if(this.listaRetorno != null && this.listaRetorno.length > 0){
       this.listaRetorno.find(x=> x.turma == turma).isOpen = true;
      }
    }

}
