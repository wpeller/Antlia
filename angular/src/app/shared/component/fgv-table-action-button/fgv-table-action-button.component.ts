import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'fgv-table-action-button',
    templateUrl: './fgv-table-action-button.component.html',
    styleUrls: ['./fgv-table-action-button.component.css']
})
export class FgvTableActionButtonComponent {

    @Input() text: string = 'Clique aqui.';
    @Input() iconClass: string = '';
    @Input() titulo: string = '';
    @Output() onClick: EventEmitter<any> = new EventEmitter<any>();

    onClickHandler(event: any): void {
        this.onClick.emit(event);
    }
}
