import { ActivatedRoute, Router } from '@angular/router';
import { AppConsts } from '@shared/AppConsts';
import { AuthService } from '@app/shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { HotSiteIncompanyLogin, HotSiteInCompanyServiceProxy, TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { TokenService } from 'abp-ng2-module/dist/src/auth/token.service';
import { UtilsService } from 'abp-ng2-module/dist/src/utils/utils.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { stringify } from 'querystring';
import { finalize } from 'rxjs/operators';
import { CustomValidators } from 'ng2-validation';
import swal from 'sweetalert2';


@Component({
  selector: 'app-redefinir-senha',
  templateUrl: './redefinir-senha.component.html',
  styleUrls: ['./redefinir-senha.component.css']
})
export class RedefinirSenhaComponent implements OnInit {


  tokenInvalido: boolean = false;
  isLoading: boolean = false;
  formCadastro: FormGroup


  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private _tokenAuthService: TokenAuthServiceProxy,
    private _tokenService: TokenService,
    private _utilsService: UtilsService,
    private _authService: AuthService,
    private hotsiteService: HotSiteInCompanyServiceProxy,
    private fb: FormBuilder) {
  }

  ngOnInit() {

    let senha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmacaoSenha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(senha)]);

    this.formCadastro = this.fb.group({
      idHotsite: [, []],
      email: [{ value: '', disabled: true }, []],
      senha: senha,
      confirmacaoSenha: confirmacaoSenha
    });


    this.isLoading = true;
    this.activatedRoute.queryParams.subscribe(params => {
      let token = params['Token'];
      abp.ui.setBusy();
      this._tokenAuthService.externalTokenHotSite(token, "Senha")
        .pipe(finalize(() => { abp.ui.clearBusy(); this.isLoading = false; }))
        .subscribe(result => {
          console.log(result);
          if (result.sucesso) {
            this.formCadastro.controls['email'].setValue(result.item.user);
            this.formCadastro.controls['idHotsite'].setValue(result.item.data);
          } else {
            this.tokenInvalido = true;
          }
        });
    });
  }

  redefinirSenha() {

    let _idHotsite = this.formCadastro.get('idHotsite').value;
    let _email = this.formCadastro.get('email').value;
    let _senha = this.formCadastro.get('senha').value;

    abp.ui.setBusy();

    this.hotsiteService.redefinirSenhaDeAcesso(_idHotsite, _email, _senha)
      .pipe(finalize(() => { abp.ui.clearBusy(); }))
      .subscribe(result => {
        this.formCadastro.reset();
        this.formCadastro.controls['email'].setValue(_email);
        swal("", "Senha alterada com sucesso", "success").then(() => {
          this.router.navigate([`hotsite/${result.item}/admin`])
        });

      });

  }


}
