import { FgvBaseComponent } from '../FgvBaseComponent';
import {
    Component,
    forwardRef,
    Input,
    OnInit,
    Output,
    EventEmitter,
} from '@angular/core';
import { FormGroup, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    // tslint:disable-next-line: no-use-before-declare
    useExisting: forwardRef(() => FgvInputSwitchComponent),
    multi: true
};

@Component({
    selector: 'fgv-input-switch',
    templateUrl: './fgv-input-switch.component.html',
    styleUrls: ['./fgv-input-switch.component.css'],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class FgvInputSwitchComponent extends FgvBaseComponent implements OnInit {

    @Input() checked: boolean | undefined;
    @Input() disabled: boolean | undefined;
    @Input() focused: boolean = false;
    @Input() styleClass: string;
    @Input() tabindex: number;

    @Output() change: EventEmitter<any> = new EventEmitter<any>();

    get getDisabled(): boolean {

        if (this.disabled) {
            return true;
        }

        if (this.formGroup.controls[this.formControlName] != null && this.formGroup.controls[this.formControlName].disabled) {
            return true;
        }

        return false;
    }

    get getChecked(): boolean {

        if (this.checked) {
            return true;
        }

        if (this.formGroup.controls[this.formControlName] != null && this.formGroup.controls[this.formControlName].value == true) {
            return true;
        }

        return false;
    }

    get getSimNao(): string {
        return this.getChecked ? 'Sim' : 'Não';
    }

    ngOnInit() {
        this.configurarControl();
    }

    private configurarControl(): void {
        let formControl = this.formGroup.controls[this.formControlName];

        if (formControl == null) {
            return;
        }

        if (formControl.value != null) {
            this.checked = formControl.value;
        } else if (this.checked != null) {
            formControl.setValue(this.checked);
        }

        if (this.disabled != null) {
            if (this.disabled)
                formControl.disable();
            else
                formControl.enable();
        }

        formControl.valueChanges
            .subscribe(x => {

                if (!this.disabled && x != null) {
                    this.checked = x[this.formControlName];
                }
            });

        formControl.statusChanges
            .subscribe(x => {
                this.disabled = formControl.disabled;
            });
    }

    onClick(cb): void {

        if (cb.disabled) {
            return;
        }

        let check = !cb.checked;
        cb.checked = check;
        this.checked = check;
        this.formGroup.controls[this.formControlName].setValue(check);

        this.change.emit(cb);
    }
}

