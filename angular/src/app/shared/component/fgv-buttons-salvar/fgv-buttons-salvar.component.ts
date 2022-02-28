import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'fgv-buttons-salvar',
    templateUrl: './fgv-buttons-salvar.component.html',
    styleUrls: ['./fgv-buttons-salvar.component.css']
})
export class FgvButtonsSalvarComponent {

    @Input() exibirVoltar: boolean = true;
    @Input() exibirSalvar: boolean = true;
    @Input() disabled: boolean = false;
    @Output() voltar: EventEmitter<any> = new EventEmitter<any>();
    @Output() salvar: EventEmitter<any> = new EventEmitter<any>();

    voltarHandler(): void {
        this.voltar.emit();
    }

    salvarHandler(): void {
        this.salvar.emit();
    }
}
