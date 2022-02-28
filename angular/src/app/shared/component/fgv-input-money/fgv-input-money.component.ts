import { Component, forwardRef, Input } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { FgvBaseComponent } from '../FgvBaseComponent';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    // tslint:disable-next-line: no-use-before-declare
    useExisting: forwardRef(() => FgvInputMoneyComponent),
    multi: true
};

@Component({
    selector: 'fgv-input-money',
    templateUrl: './fgv-input-money.component.html',
    styleUrls: ['./fgv-input-money.component.css'],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class FgvInputMoneyComponent extends FgvBaseComponent {

    forMoney: RegExp = /^[0-9\,]+$/;

    @Input() min: string;
    @Input() max: string;
    @Input() minlength: string;
    @Input() maxlength: string;
    @Input() size: string;

    validar(_value: string): void {

        if (this.formGroup == null || this.formControlName == null) {
            return;
        }

        let _control = this.formGroup.controls[this.formControlName];

        if (_control == null) {
            return;
        }

        let v = '';

        if (_value != null) {

            let caracterPermitido: string[] = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
            let _addDecimal: boolean = false;
            for (var i = 0; i < _value.length; i++) {
                let c = _value.charAt(i);

                if (c == ',' && !_addDecimal) {
                    if (i == 0) {
                        v += '0';
                    }

                    v += c;
                    _addDecimal = true;
                } else if (caracterPermitido.some(x => x == c)) {
                    v += c;
                }
            }
        }

        _control.setValue(v);
    }

    getNumber(): number {
        if (this.formGroup == null || this.formControlName == null) {
            return 0;
        }

        let _control = this.formGroup.controls[this.formControlName];

        if (_control == null) {
            return 0;
        }

        let v: string = _control.value;
        v = v.replace(',', '.');

        return Number(v);
    }
}
