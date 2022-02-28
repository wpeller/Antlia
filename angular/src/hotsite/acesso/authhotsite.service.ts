import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HotSiteInCompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

import { Usuario } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthhotsiteService {

    private usuarioAutenticado: boolean = false;
    private mostrarMenu: boolean = false;

    mostrarMenuEmitter = new EventEmitter<boolean>();

    constructor(private router: Router,
        private hotsiteService: HotSiteInCompanyServiceProxy
        ) { }

    fazerLogin(usuario: Usuario){
        //TODO: enviar o idHotSite
        this.hotsiteService.verificarLogin(usuario.email, btoa(usuario.senha), usuario.idHotSite, usuario.nomeHotSite)
        .pipe(finalize(()=>{abp.ui.clearBusy();}))
        .subscribe(result=>{
          if(result.sucesso){
            this.usuarioAutenticado = true;
            this.mostrarMenu = true;
            console.log(this.usuarioAutenticado);
            this.router.navigate(['/hotsite/' + usuario.nomeHotSite + '/gerenciar-inscritos']);
          }
          else
          {
            this.usuarioAutenticado = false;
            this.mostrarMenu = false;

            this.mostrarMenuEmitter.emit(false);
            abp.message.error(result.mensagem)
          }
        });
    }

    usuarioEstaAutenticado(){
      return this.usuarioAutenticado;
    }

    menuDeveSerExibido(){
        return this.mostrarMenu;
      }
}
