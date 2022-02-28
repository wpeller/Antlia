import { AuthhotsiteService } from './../authhotsite.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@app/shared/services/auth.service';
import { UtilsService } from '@metronic/app/core/services/utils.service';
import { HotSiteInCompanyServiceProxy, TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { TokenService } from 'abp-ng2-module/dist/src/auth/token.service';
import { finalize } from 'rxjs/operators';
import { Usuario } from '../usuario';

@Component({
  selector: 'app-hotsite-login',
  templateUrl: './hotsite-login.component.html',
  styleUrls: ['./hotsite-login.component.css']
})
export class HotsiteLoginComponent implements OnInit {

    tokenInvalido: boolean = false;
    isLoading:boolean = false;
    formLogin: FormGroup
    usuario: Usuario = new Usuario();
    nomeHotsite: string;
    idHotSite: number;

      constructor(
          private activatedRoute: ActivatedRoute,
          private _router: Router,
          private _tokenAuthService: TokenAuthServiceProxy,
          private _tokenService: TokenService,
          private _utilsService: UtilsService,
          private _authService: AuthService,
          private authService: AuthhotsiteService,
          private fb: FormBuilder,
          private hotsiteService: HotSiteInCompanyServiceProxy,) { }

    ngOnInit() {

        this.activatedRoute.url.subscribe(url => {
            if (url[0].path.length > 0) {
                this.nomeHotsite=  url[0].path;
                this.hotsiteService.buscarHotSiteInCompanyByNome(this.nomeHotsite)
                .pipe(finalize(()=>{abp.ui.clearBusy();}))
                .subscribe(result=>{
                  if(result.id){
                      this.idHotSite = result.id;
                  }
                  else
                  {
                    this.idHotSite=0;
                    abp.message.error('Não foi encontrado HotSite com o nome informado.');
                  }
                });
              }
        });
        let senha = new FormControl('', [Validators.required] );
        let email = new FormControl('', [Validators.required] );



      this.formLogin = new FormGroup({
          email: email,
          senha: senha
       });
    }

    verificarAcesso(){

      let _email = this.formLogin.get('email').value;
      let _senha = this.formLogin.get('senha').value;
      if(!_email || _email.trim().length === 0 )
      {
        abp.message.error('Por favor, informe o e-mail.');
        return;
      }

      if(!_senha || _senha.trim().length === 0 )
      {
        abp.message.error('Por favor, informe a senha.');
        return;
      }

      if (this.nomeHotsite.trim().length <= 0 )
      {
        abp.message.error('Nome do HotSite não informado.');
        return;
      }

      abp.ui.setBusy();
      this.usuario.email= _email;
      this.usuario.senha= _senha;
      this.usuario.idHotSite = this.idHotSite;
      this.usuario.nomeHotSite = this.nomeHotsite.trim();
      this.authService.fazerLogin(this.usuario);
    }

}
