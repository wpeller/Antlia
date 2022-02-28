import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvMenuHorizontalComponent } from './fgv-menu-horizontal.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [FgvMenuHorizontalComponent],
    exports: [FgvMenuHorizontalComponent],
    bootstrap: [FgvMenuHorizontalComponent],
})
export class FgvMenuHorizontalModule { }
