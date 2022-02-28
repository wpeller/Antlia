import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { MovimentoServicoServiceProxy, Movimento_ManualDto, ProdutoCosifServiceProxy, ProdutoServiceProxy } from '@shared/service-proxies/service-proxies';
import { MessageService } from 'abp-ng2-module/dist/src/message/message.service';
import { GenericItem } from 'ngx-siga2-componentes';
import { SelectItem } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-movimento-cadastro',
  templateUrl: './movimento-cadastro.component.html',
  styleUrls: ['./movimento-cadastro.component.css']
})
export class MovimentoCadastroComponent implements OnInit {

  formBuilder: FormBuilder;
  private message: MessageService;
  produtos: SelectItem[] = [];
  produtoCosif: SelectItem[] = [];
  @ViewChild('dataTable') dataTable: Table;
  primengTableHelper: PrimengTableHelper;
  
  formMovimento: FormGroup = new FormGroup({
    txtMes: new FormControl('', []),
    txtAno: new FormControl('', []),
    ddlProduto: new FormControl('', []),
    ddlCosif: new FormControl('', []),
    txtValor: new FormControl('', []),
    txtDescricao: new FormControl('', [])
  });

  constructor(injector: Injector, private titleService: Title,
    private _movimento: MovimentoServicoServiceProxy,
    private _produto: ProdutoServiceProxy,
    private _produtoCosif: ProdutoCosifServiceProxy,) {
    this.formBuilder = injector.get(FormBuilder);

    this.message = injector.get(MessageService);

    this.primengTableHelper = new PrimengTableHelper();


  }


  ngOnInit() {
    this.buscar();


    this.BindProduto();
  }

  public BindProduto() {
    this.produtos = [];



    this._produto.buscarTodos()
      .pipe(finalize(() => { }))
      .subscribe(x => {
        if (x == null) {
          this.message.error('Erro ao buscar programas.');
        }
        else if (x != null) {
          x.sort((a, b) => a.deS_PRODUTO.localeCompare(b.deS_PRODUTO))
            .forEach(element => {
              this.produtos.push(new GenericItem(element.deS_PRODUTO, element.id));
            });
        }
      });


  }

  public SelecionarProduto() {
    this.produtoCosif = [];

    let _idProduto: string = this.formMovimento.controls.ddlProduto.value;


    if (_idProduto.length == 0) {
      return;
    }

    this._produtoCosif.buscarPorIdProduto(_idProduto)
      .pipe(finalize(() => { }))
      .subscribe(x => {
        if (x == null) {
          this.message.error('Erro ao buscar programas.');
        }
        else if (x != null) {
          x.sort((a, b) => a.coD_COSIF.localeCompare(b.coD_COSIF))
            .forEach(element => {
              this.produtoCosif.push(new GenericItem(element.coD_COSIF + ' - ' + element.coD_CLASSIFICACAO, element.coD_COSIF));
            });
        }
      });


  }

  public NovoOnClick() {

    this.formMovimento.reset();
  }

  public LimparOnClick() {

    this.formMovimento.reset();
  }

  public SalvarOnClick() {


    let _movimento: Movimento_ManualDto = new Movimento_ManualDto();

    _movimento.daT_ANO = this.formMovimento.controls.txtAno.value;
    _movimento.daT_MES = this.formMovimento.controls.txtMes.value;
    _movimento.vaL_VALOR = this.formMovimento.controls.txtValor.value;
    _movimento.deS_DESCRICAO = this.formMovimento.controls.txtDescricao.value;
    _movimento.coD_PRODUTO = this.formMovimento.controls.ddlProduto.value;
    _movimento.produtoCod = this.formMovimento.controls.ddlProduto.value;
    _movimento.coD_COSIF = this.formMovimento.controls.ddlCosif.value;
    _movimento.coD_USUARIO = "TESTE"

    this._movimento.gravar(_movimento)
      .pipe(finalize(() => { }))
      .subscribe(x => {
        if (x == null) {
          this.message.error('Erro gravar movimento.');
        }

        if (x.sucesso == false) {

          this.message.error(x.mensagem);
        }

        this.message.success(x.mensagem);
        this.LimparOnClick();
        this.buscar();


      });

  }

  private buscar( ): void {
    

    this._movimento.buscarTodos()
        .pipe(finalize(() => {  }))
        .subscribe(result => {

            if (result == null  ) {
                this.message.error('Erro ao buscar.');
            }  else if (result != null) {
             this.primengTableHelper.records = result;
            }
        });
}

 

}


