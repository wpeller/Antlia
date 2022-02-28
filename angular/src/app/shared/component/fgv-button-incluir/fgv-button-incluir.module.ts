import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvButtonModule } from '../fgv-button/fgv-button.module';
import { FgvButtonIncluirComponent } from './fgv-button-incluir.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvButtonModule
    ],
    declarations: [FgvButtonIncluirComponent],
    exports: [FgvButtonIncluirComponent],
    bootstrap: [FgvButtonIncluirComponent],
})
export class FgvButtonIncluirModule { }
