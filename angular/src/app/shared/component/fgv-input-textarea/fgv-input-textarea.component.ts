import { Component, forwardRef, Input } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { FgvBaseComponent } from '../FgvBaseComponent';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => FgvInputTextAreaComponent),
    multi: true
};

@Component({
    selector: 'fgv-input-textarea',
    templateUrl: './fgv-input-textarea.component.html',
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})

export class FgvInputTextAreaComponent extends FgvBaseComponent {
    @Input() maxlength: string;
    @Input() minlength: string;
    @Input() rows: number;
    @Input() cols: number;
}
