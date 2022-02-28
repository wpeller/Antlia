import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvRodapeComponent } from './fgv-rodape.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [FgvRodapeComponent],
    exports: [FgvRodapeComponent],
    bootstrap: [FgvRodapeComponent],
})
export class FgvRodapeModule { }
