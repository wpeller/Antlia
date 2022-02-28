import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { FgvTableActionContentComponent } from './fgv-table-action-content.component';

@NgModule({
    imports: [BsDropdownModule.forRoot(), DropdownModule, CommonModule],
    declarations: [FgvTableActionContentComponent],
    exports: [FgvTableActionContentComponent],
    bootstrap: [FgvTableActionContentComponent],
})
export class FgvTableActionContentModule { }
