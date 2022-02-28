import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'fgv-modal',
    templateUrl: './fgv-modal.component.html',
    styleUrls: ['./fgv-modal.component.css']
})
export class FgvModalComponent {

    @ViewChild('Modal') modal: ModalDirective;

    @Input() title: string;

    @Output() onShow: EventEmitter<any> = new EventEmitter<any>();
    @Output() onClose: EventEmitter<any> = new EventEmitter<any>();

    exibir: boolean = true;

    public show(): void {
        this.exibir = true;
        this.modal.show();
        this.onShow.emit();
    }

    public close(): void {
        this.hide();
    }

    public hide(): void {
        this.exibir = false;
        this.modal.hide();
        this.onClose.emit();
    }
}
