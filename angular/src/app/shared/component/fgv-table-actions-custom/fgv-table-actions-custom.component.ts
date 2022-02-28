import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
    selector: 'fgv-table-actions-custom',
    templateUrl: './fgv-table-actions-custom.component.html',
    styleUrls: ['./fgv-table-actions-custom.component.css']
})
export class FgvTableActionsCustomComponent {
    @Input() titulo: string = '';
    @Input() texto: string = 'Default';
    @Output() acao: EventEmitter<any> = new EventEmitter<any>();

    ngOnInit() {
        if (this.titulo != '')
            this.titulo = this.titulo + '  ';
    }

    acaoHandler(event): void {
        this.acao.emit(event);
    }
}

