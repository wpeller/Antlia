import { Component, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { FgvBaseComponent } from '../FgvBaseComponent';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    // tslint:disable-next-line: no-use-before-declare
    useExisting: forwardRef(() => FgvInputCpfComponent),
    multi: true,
};

@Component({
    selector: 'fgv-input-cpf',
    templateUrl: './fgv-input-cpf.component.html',
    styleUrls: ['./fgv-input-cpf.component.css'],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
})
export class FgvInputCpfComponent extends FgvBaseComponent {

    onFocusOutHandler(texto: string): void {
        if (!this.validarCPF(texto)) {
            this.formGroup.get(this.formControlName).setErrors({ 'cpfInvalido': 'CPF inválido' });
        }
    }

    validarCPF(cpf: string): boolean {

        if (cpf == null || cpf == '') {
            return false;
        }

        if (cpf.length != 11 && cpf.length != 14) {
            return false;
        }

        var aux = '';
        for (var i = 0; i < cpf.length; i++) {
            let c = cpf.charAt(i);

            let n = Number(c).toString();

            if (n == 'NaN' && c != '.' && c != '-') {
                return false;
            }

            if (n != 'NaN') {
                aux += n;
            }
        }

        cpf = aux;

        if (cpf.length != 11) {
            return false;
        }

        let tudoIgual = true;
        for (var i = 1; i < cpf.length; i++) {
            if (cpf.charAt(i - 1) != cpf.charAt(i)) {
                tudoIgual = false;
                break;
            }
        }

        if (tudoIgual) {
            return false;
        }

        let Soma = 0;

        for (var i = 1; i <= 9; i++) {
            Soma = Soma + parseInt(cpf.substring(i - 1, i)) * (11 - i);
        }

        let Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11)) {
            Resto = 0;
        }

        if (Resto != parseInt(cpf.substring(9, 10))) {
            return false;
        }

        Soma = 0;
        for (var i = 1; i <= 10; i++) {
            Soma = Soma + parseInt(cpf.substring(i - 1, i)) * (12 - i);
        }

        Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11)) {
            Resto = 0;
        }

        if (Resto != parseInt(cpf.substring(10, 11))) {
            return false;
        }

        return true;
    }
}
