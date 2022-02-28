import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TesteComponent } from './teste.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [TesteComponent],
    exports: [TesteComponent],
    bootstrap: [TesteComponent],
    providers: []
})
export class TesteModule { }
