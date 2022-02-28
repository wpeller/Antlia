import { CommonModule } from '@angular/common';
import { FgvButtonsSalvarComponent } from './fgv-buttons-salvar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { FgvButtonModule } from '../fgv-button/fgv-button.module';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
        ReactiveFormsModule,
        FgvButtonModule,
	],
	declarations: [ FgvButtonsSalvarComponent ],
	exports: [ FgvButtonsSalvarComponent ],
	bootstrap: [ FgvButtonsSalvarComponent ],
})
export class FgvButtonsSalvarModule {}
