import { AdicionarFavoritoInput, NavigationDto, MenuServicoServiceProxy, ObterItemDeMenuPorIdInput } from '@shared/service-proxies/service-proxies';
import { AppConsts } from '@shared/AppConsts';
import {
  Component,
  Input,
  OnInit
  } from '@angular/core';
import { NavegacaoService } from '@app/shared/services/navegacao.service';
import { PapelService } from '@app/shared/services/papel.service';
import { UsuarioService } from '@app/shared/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bread-crumb-default',
  templateUrl: './bread-crumb-default.component.html',
  styleUrls: ['./bread-crumb-default.component.css']
})
export class BreadCrumbDefaultComponent implements OnInit {

  @Input() breadcrumb: string;
  ehHome: boolean;
  ambiente: string;
  favorito: boolean;
  titulo: string;


  navigation: NavigationDto;

  constructor(private navegacaoService: NavegacaoService,
    private menuServico: MenuServicoServiceProxy,
    private papelService: PapelService,
    private router: Router,
    private usuarioService: UsuarioService) { }

    ngOnInit() {
      this.ehHome = false;
      this.favorito = false;
      this.ambiente = AppConsts.ambiente;
      this.ambiente = this.ambiente.toLowerCase();
      this.ambiente = this.ambiente.trim();
  
      if (this.ambiente === 'ambiente: produção') {
          this.ambiente = '';
      }
      this.navigation = this.navegacaoService.navegacaoAtual;
      if (this.navigation && this.navigation.name) {
        this.getBreadBrumb();
        if (this.navigation.rota.indexOf('dashboard') > 0) {
          this.ehHome = true;
        } else {
          this.ehHome = false;
        }
      } else {
        abp.event.on('app.auth.canActivate', navigation => { //see auth-route.guard.ts
          if (navigation && navigation.name) {
            this.navigation = navigation;
            this.favorito = navigation.favorito;
            this.getBreadBrumb();
          }
        });
      }
    }
  
    getBreadBrumb(): void {
      let input = new ObterItemDeMenuPorIdInput();
      input.idItemMenu = this.navigation.id;
      this.menuServico.obterItemDeMenuPorId(input).toPromise()
        .then(y => {
          if (y.breadCrumb) {
            this.breadcrumb = y.breadCrumb;
            this.titulo = y.titulo;
          }
        });
    }

    verificar(): void {
      if (this.favorito) {
        this.removerFavoritos();
      } else {
        this.adicionarFavoritos();
      }
    }

    adicionarFavoritos(): void {
      let input = new AdicionarFavoritoInput();
      let userName = this.usuarioService.obterUserName();
      let papel = this.papelService.obterPapelAtual();
      input.idPapel = papel.id;
      input.idRecurso = this.navigation.id;
      input.codigoExternoUsuario = userName;
      this.menuServico.adicionarFavorito(input)
      .subscribe(result => {
        abp.message.success('Adicionado aos favoritos!');
      });
    }
  
    removerFavoritos(): void {
      abp.message.confirm('Deseja excluir este item da sua lista de favoritos?', (p) => {
        if (p) {
          let userName = this.usuarioService.obterUserName();
          let papel = this.papelService.obterPapelAtual();
          this.menuServico.removerFavorito(
            userName,
            papel.id,
            this.navigation.id)
            .subscribe( () => {
              abp.message.success('Registro excluído com sucesso!');
            });
        }
    });
    }
  
    private getCurrentRouterUrl(): any {
      let currentRoute = this.router.url;
      return currentRoute;
    }
}