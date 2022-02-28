import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FgvButtonsSalvarModule } from '../fgv-buttons-salvar/fgv-buttons-salvar.module';
import { FgvCardFormComponent } from './fgv-card-form.component';

@NgModule({
	imports: [ CommonModule , FgvButtonsSalvarModule],
	declarations: [ FgvCardFormComponent ],
	exports: [ FgvCardFormComponent ],
})
export class FgvCardFormModule {}
