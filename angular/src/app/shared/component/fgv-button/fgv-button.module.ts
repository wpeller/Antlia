import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvButtonComponent } from './fgv-button.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [FgvButtonComponent],
    exports: [FgvButtonComponent],
    bootstrap: [FgvButtonComponent]
})
export class FgvButtonModule { }
