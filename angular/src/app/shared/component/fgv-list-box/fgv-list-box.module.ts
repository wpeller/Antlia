import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvListBoxComponent } from './fgv-list-box.component';
import { FgvButtonModule } from '../fgv-button/fgv-button.module';
import { ProgressBarModule } from 'primeng/primeng';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvButtonModule,
        ProgressBarModule,
    ],
    declarations: [FgvListBoxComponent],
    exports: [FgvListBoxComponent],
    bootstrap: [FgvListBoxComponent]
})
export class FgvListBoxModule { }
