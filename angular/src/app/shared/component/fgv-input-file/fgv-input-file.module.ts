import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, ModalModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { FgvTableActionButtonModule } from '../fgv-table-action-button/fgv-table-action-button.module';
import { FgvTableActionContentModule } from '../fgv-table-action-content/fgv-table-action-content.module';
import { FgvInputFileComponent } from './fgv-input-file.component';
import { TableModule } from 'primeng/table';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ModalModule,
        ReactiveFormsModule,
        BsDropdownModule.forRoot(),
        DropdownModule,
        FgvTableActionButtonModule,
        FgvTableActionContentModule,
        TableModule
    ],
    declarations: [FgvInputFileComponent],
    exports: [FgvInputFileComponent],
    bootstrap: [FgvInputFileComponent]
})
export class FgvInputFileModule { }
