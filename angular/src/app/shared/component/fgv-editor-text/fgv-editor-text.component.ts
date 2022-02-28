import { AfterViewInit, Component, EventEmitter, forwardRef, Input, OnInit, Output } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { FgvBaseComponent } from '../FgvBaseComponent';

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    // tslint:disable-next-line: no-use-before-declare
    useExisting: forwardRef(() => FgvEditorTextComponent),
    multi: true
};

@Component({
    selector: 'fgv-editor-text',
    templateUrl: './fgv-editor-text.component.html',
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class FgvEditorTextComponent extends FgvBaseComponent implements OnInit, AfterViewInit {
    idComponent: string = this.newGuid();
    delayJsMilliseconds: number = 1000 * 1;

    @Input() toolbarOptionsCustom: fgvEditorTextToolbarOption[] = [];
    @Input() toolbar: fgvEditorTextToolbar = fgvEditorTextToolbar.fgv;
    @Input() defaultHtml: string = '';
    @Output() onFocus: EventEmitter<any> = new EventEmitter<any>();
    @Output() onFocusOut: EventEmitter<any> = new EventEmitter<any>();

    ngOnInit() {
    }

    ngAfterViewInit() {
        this.configCkEditor(true);
    }

    private newGuid(): string {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    private configCkEditor(delay?: boolean): void {
        let varFromJsFile = window["CKEDITOR"];

        if (varFromJsFile != null) {
            this.replaceTextAreaToCkEditor(varFromJsFile);
            this.configToolBar(varFromJsFile);
            this.setHtml(this.defaultHtml);
            this.onFocusHandler(varFromJsFile);
            this.onFocusOutHandler(varFromJsFile);
            this.onKeyPressHandler(varFromJsFile);
        } else if (delay) {
            setTimeout(() => { this.configCkEditor(false); }, this.delayJsMilliseconds);
        }
    }

    private replaceTextAreaToCkEditor(editor: any): void {
        if (editor == null) {
            return;
        }

        editor.replace(this.idComponent);
    }

    private configToolBar(editor: any): void {
        if (this.toolbar == fgvEditorTextToolbar.basic) {
            editor.instances[this.idComponent].config.toolbar = 'Basic';
        } else if (this.toolbar == fgvEditorTextToolbar.full) {
            editor.instances[this.idComponent].config.toolbar = 'Full';
        } else if (this.toolbar == fgvEditorTextToolbar.custom) {

            if (this.toolbarOptionsCustom == null || this.toolbarOptionsCustom.length <= 0) {
                editor.instances[this.idComponent].config.toolbar = 'Full';
            } else {
                editor.instances[this.idComponent].config.toolbar = 'Basic';
                editor.instances[this.idComponent].config.toolbar_Basic = this.toolbarOptionsCustom;
            }
        }
        else {
            editor.instances[this.idComponent].config.font_defaultLabel = 'Times New Roman';
            editor.instances[this.idComponent].config.toolbar = 'Basic';
            editor.instances[this.idComponent].config.toolbar_Basic = [['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Font', '-', 'Image', '-', 'PasteFromWord', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'Table']];
            editor.instances[this.idComponent].config.enterMode = 'BR';
            editor.instances[this.idComponent].config.shiftEnterMode = 'BR';
            editor.instances[this.idComponent].config.toolbarCanCollapse = false;
        }
    }

    onFocusHandler(editor: any) {
        if (editor == null) {
            return;
        }

        editor.instances[this.idComponent].on('focus', () => { this.onFocus.emit(); });
    }

    onFocusOutHandler(editor: any) {
        if (editor == null) {
            return;
        }

        editor.instances[this.idComponent].on('blur', () => { this.onFocusOut.emit(); });
    }

    onKeyPressHandler(editor: any) {
        if (editor == null) {
            return;
        }
        
        editor.instances[this.idComponent].on('key', () => { this.setValueControl(); });
    }

    insertHtml(html: string, delay?: boolean): void {
        let varFromJsFile = window["CKEDITOR"];

        if (varFromJsFile != null && varFromJsFile.instances[this.idComponent] != null) {
            varFromJsFile.instances[this.idComponent].insertHtml(html);
            this.setValueControl();
        } else if (delay) {
            setTimeout(() => { this.insertHtml(html, false) }, this.delayJsMilliseconds);
        }
    }

    setHtml(html: string, delay?: boolean): void {
        let varFromJsFile = window["CKEDITOR"];

        if (varFromJsFile != null && varFromJsFile.instances[this.idComponent] != null) {
            varFromJsFile.instances[this.idComponent].setData(html);
            this.setValueControl();
        } else if (delay) {
            setTimeout(() => { this.setHtml(html, false) }, this.delayJsMilliseconds);
        }
    }

    getHtml(): string {
        let varFromJsFile = window["CKEDITOR"];

        if (varFromJsFile != null && varFromJsFile.instances[this.idComponent] != null) {
            return varFromJsFile.instances[this.idComponent].getData();
        }

        return '';
    }

    getToolbarOptionsFull(): fgvEditorTextToolbarOption[] {
        let retorno: fgvEditorTextToolbarOption[] = [];

        let varFromJsFile = window["CKEDITOR"];

        if (varFromJsFile != null) {
            retorno = varFromJsFile.config.toolbar_Full;
        }

        return retorno;
    }

    private setValueControl(): void {
        if (this.formGroup == null || this.formControlName == null || this.formControlName == '') {
            return;
        }

        let control = this.formGroup.get(this.formControlName);

        if (control == null) {
            return;
        }

        let _html = this.getHtml();

        if (_html == control.value) {
            return;
        }

        control.setValue(_html);
        //control.markAsTouched({ onlySelf: true });
    }
}

export enum fgvEditorTextToolbar {
    fgv = 0,
    basic = 1,
    full = 2,
    custom = 3,
}

export class fgvEditorTextToolbarOption {
    name: string
    items: string[]
}
