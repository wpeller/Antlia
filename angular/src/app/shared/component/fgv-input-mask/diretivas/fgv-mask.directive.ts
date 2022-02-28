import { Directive, Input, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[mask]',
})
export class FgvMaskDirective {
    @Input('mask') mask: string;

    constructor(private element: ElementRef) { }

    @HostListener('input', ['$event'])
    onInputChange(event) {
        if (event.inputType == 'deleteContentBackward') return;

        let initalValue: string = this.element.nativeElement.value;

        if (initalValue != null) {
            initalValue = initalValue.replace(/[^0-9]*/g, '');
        }

        if (initalValue !== this.element.nativeElement.value) {
            event.stopPropagation();
        }

        this.element.nativeElement.value = this.format(this.mask, initalValue);
    }

    format(mask: string, value: any): string {
        let text = '';
        let data = value;
        let c, m, i, x;

        for (i = 0, x = 1; x && i < mask.length; ++i) {

            if (data != null) {
                c = data.charAt(i);
            }

            m = mask.charAt(i);

            switch (mask.charAt(i)) {
                case '#':
                    if (/\d/.test(c)) {
                        text += c;
                    } else {
                        x = 0;
                    }
                    break;

                case 'A':
                    if (/[a-z]/i.test(c)) {
                        text += c;
                    } else {
                        x = 0;
                    }
                    break;

                case 'N':
                    if (/[a-z0-9]/i.test(c)) {
                        text += c;
                    } else {
                        x = 0;
                    }
                    break;

                case 'X':
                    text += c;
                    break;

                default:
                    text += m;
                    break;
            }
        }
        return text;
    }
}
