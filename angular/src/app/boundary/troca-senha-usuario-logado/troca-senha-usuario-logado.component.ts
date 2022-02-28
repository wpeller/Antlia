import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBaseSiga2 } from '@shared/common/app-component-base-siga2';
import { Router, ActivatedRoute } from '@angular/router';
import { AppSessionService } from '@shared/common/session/app-session.service';
import { UsuarioServicoServiceProxy, TrocaDeSenhaInput, UsuarioSigaDoisDto } from '@shared/service-proxies/service-proxies';
import { PapelService } from '@app/shared/services/papel.service';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { finalize } from 'rxjs/operators';
import { UsuarioService } from '@app/shared/services/usuario.service';

@Component({
  selector: 'app-troca-senha-usuario-logado',
  templateUrl: './troca-senha-usuario-logado.component.html',
  styleUrls: ['./troca-senha-usuario-logado.component.css'],
  animations: [appModuleAnimation()]
})
export class TrocaSenhaUsuarioLogadoComponent extends AppComponentBaseSiga2 implements OnInit {

  senhaContrato: Boolean = false;
  senhaUsuario: Boolean = false;
  senhaFinanceira: Boolean = false;
  trocaSenha: any = { senhaAutenticacao: '', novaSenha: '', confirmacaoSenha: '' };
  usuario: UsuarioSigaDoisDto;

  constructor(
    injector: Injector,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _appSessionService: AppSessionService,
    private _service: UsuarioServicoServiceProxy,
    private _papelService: PapelService,
    private _usuarioService: UsuarioService
  ) {
    super(injector);
  }

  ngOnInit() {
    abp.ui.setBusy();
    
    this._service.obterUsuarioPorCodigoExterno(this._usuarioService.obterUserName())
    .pipe(finalize(() => abp.ui.clearBusy()))
    .subscribe( p=> {
      this.usuario = p;
    })
    this.senhaUsuario = true;
  }

  alterarSenha(): void {
    abp.ui.setBusy();

    let trocaSenhaDto: TrocaDeSenhaInput = new TrocaDeSenhaInput();
    trocaSenhaDto.login = this._usuarioService.obterUserName();
    trocaSenhaDto.tipoSenha = this.DefineTipoDeSenhaASerAlterada();
    trocaSenhaDto.senhaAtual = this.trocaSenha.senhaAutenticacao;
    trocaSenhaDto.senhaNova = this.trocaSenha.novaSenha;
    trocaSenhaDto.confirmacaoSenhaNova = this.trocaSenha.confirmacaoSenha;

    this._service.alterarSenhaUsuarioLogado(trocaSenhaDto)
      .pipe(finalize(() => abp.ui.clearBusy()))
      .subscribe(p => {
        if (p.sucesso) {
          abp.message.success('Senha Alterada com sucesso');
          this._router.navigate(['app/dashboard']);
        } else {
          abp.message.error(p.mensagem, 'Erro ao alterar a senha!', true);
        }
      });
  }
  DefineTipoDeSenhaASerAlterada(): number {
    if (this.senhaContrato) return 2;
    if (this.senhaFinanceira) return 1;
    if (this.senhaUsuario) return 0;
  }

}
