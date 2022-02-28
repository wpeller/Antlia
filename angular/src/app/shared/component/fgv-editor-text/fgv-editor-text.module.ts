import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvEditorTextComponent } from './fgv-editor-text.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [FgvEditorTextComponent],
    exports: [FgvEditorTextComponent],
    bootstrap: [FgvEditorTextComponent]
})
export class FgvEditorTextModule { }
