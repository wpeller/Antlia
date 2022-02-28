import { Component, Input } from '@angular/core';
import { FgvTableActionsButton } from './fgv-table-actions-custom-list.model';

@Component({
    selector: 'fgv-table-actions-custom-list',
    templateUrl: './fgv-table-actions-custom-list.component.html',
    styleUrls: ['./fgv-table-actions-custom-list.component.css']
})
export class FgvTableActionsCustomListComponent {
    @Input() titulo: string = '';
    //@Input() botoes: FgvTableActionsButton[] = [];

    ngOnInit() {
        if (this.titulo != '')
            this.titulo = this.titulo + '  ';
    }

    acaoHandler(botao: any): void {
        //botao.acao(botao.parametroAcao);
    }
}

