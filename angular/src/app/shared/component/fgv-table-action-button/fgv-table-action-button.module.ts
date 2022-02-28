import { NgModule } from '@angular/core';
import { FgvTableActionButtonComponent } from './fgv-table-action-button.component';
import { BsDropdownModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        CommonModule,
        BsDropdownModule.forRoot(),
        DropdownModule
    ],
    declarations: [FgvTableActionButtonComponent],
    exports: [FgvTableActionButtonComponent],
    bootstrap: [FgvTableActionButtonComponent],
})
export class FgvTableActionButtonModule { }
