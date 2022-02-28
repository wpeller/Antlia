import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, ModalModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, InputSwitchModule, InputTextModule, KeyFilterModule, PaginatorModule, PickListModule, ProgressBarModule } from 'primeng/primeng';
import { FgvInputCpfComponent } from './fgv-input-cpf.component';

@NgModule({
    imports: [
        BsDropdownModule,
        CommonModule,
        CommonModule,
        FormsModule,
        InputMaskModule,
        InputSwitchModule,
        InputTextModule,
        KeyFilterModule,
        ModalModule,
        PaginatorModule,
        PickListModule,
        PrimeNgFileUploadModule,
        ProgressBarModule,
        ReactiveFormsModule,
        TabsModule,
        TooltipModule,
    ],
    declarations: [FgvInputCpfComponent],
    exports: [FgvInputCpfComponent],
    bootstrap: [FgvInputCpfComponent]
})
export class FgvInputCpfModule { }
