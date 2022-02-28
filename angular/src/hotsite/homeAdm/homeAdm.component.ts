import { Component, OnInit } from '@angular/core';
import { AuthhotsiteService } from 'hotsite/acesso/authhotsite.service';

@Component({
  selector: 'app-homeAdm',
  templateUrl: './homeAdm.component.html',
  styleUrls: ['./homeAdm.component.css']
})
export class HomeAdmComponent implements OnInit {

  mostrarMenu: boolean = false;
  idHotSite: number;
  usuarioAutenticado: boolean =false;

  constructor(private authService: AuthhotsiteService) { }

  ngOnInit() {
    this.usuarioAutenticado = this.authService.usuarioEstaAutenticado();
    console.log(this.usuarioAutenticado);

    this.authService.mostrarMenuEmitter.subscribe(
         mostrar => this.mostrarMenu = mostrar
     );
     console.log(this.mostrarMenu);

     this.mostrarMenu=this.usuarioAutenticado = this.authService.menuDeveSerExibido();
     console.log(this.mostrarMenu);

     this.idHotSite = 40;

  }

}
