import { CommonModule } from '@angular/common';
import { FgvButtonsBuscarComponent } from './fgv-buttons-buscar.component';
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
	declarations: [ FgvButtonsBuscarComponent ],
	exports: [ FgvButtonsBuscarComponent ],
	bootstrap: [ FgvButtonsBuscarComponent ]
})
export class FgvButtonsBuscarModule {}
