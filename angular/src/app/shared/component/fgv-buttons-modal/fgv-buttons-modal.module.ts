import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, ModalModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { FileUploadModule as PrimeNgFileUploadModule, InputSwitchModule, InputTextModule, PaginatorModule, PickListModule, ProgressBarModule } from 'primeng/primeng';
import { FgvButtonModule } from '../fgv-button/fgv-button.module';
import { FgvButtonsModalComponent } from './fgv-buttons-modal.component';

@NgModule({
	imports: [
		BsDropdownModule,
		CommonModule,
		FormsModule,
		InputSwitchModule,
		InputTextModule,
		ModalModule,
		PaginatorModule,
		PickListModule,
		PrimeNgFileUploadModule,
		ProgressBarModule,
		ReactiveFormsModule,
		TabsModule,
        TooltipModule,
        FgvButtonModule,
	],
	declarations: [ FgvButtonsModalComponent ],
	exports: [ FgvButtonsModalComponent ],
})
export class FgvButtonsModalModule {}
