import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvInputTextAreaComponent } from './fgv-input-textarea.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [FgvInputTextAreaComponent],
    exports: [FgvInputTextAreaComponent],
    bootstrap: [FgvInputTextAreaComponent],
})
export class FgvInputTextAreaModule { }
