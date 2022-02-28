import { Component, EventEmitter, forwardRef, Input, Output } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { FgvBaseComponent } from '../FgvBaseComponent';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    // tslint:disable-next-line: no-use-before-declare
    useExisting: forwardRef(() => FgvInputTextComponent),
    multi: true
};

@Component({
    selector: 'fgv-input-text',
    templateUrl: './fgv-input-text.component.html',
    styleUrls: ['./fgv-input-text.component.css'],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class FgvInputTextComponent extends FgvBaseComponent {

    @Input() maxlength: string;
    @Input() minlength: string;

    @Output() onFocus: EventEmitter<any> = new EventEmitter<any>();
    @Output() onFocusOut: EventEmitter<any> = new EventEmitter<any>();

    onFocusHandler(event): void {
        this.onFocus.emit(event);
    }

    onFocusOutHandler(event): void {
        this.onFocusOut.emit(event);
    }
}
