import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvBadgeComponent } from './fgv-badge.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    declarations: [FgvBadgeComponent],
    exports: [FgvBadgeComponent],
    bootstrap: [FgvBadgeComponent]
})
export class FgvBadgeModule { }
