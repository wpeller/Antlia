import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GerenciarInscritosComponent } from 'hotsite/gerenciar-inscritos/gerenciar-inscritos.component';
import { TableModule } from 'primeng/table';
import { PaginatorModule } from 'primeng/paginator';

import { FgvCardModule, FgvInputEmailModule, FgvInputPasswordModule, FgvInputTextModule } from 'ngx-siga2-componentes';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UtilsModule } from '@shared/utils/utils.module';
import { AccordionModule, CheckboxModule } from 'primeng/primeng';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    TableModule,
            PaginatorModule,
            FgvInputPasswordModule,
            FgvInputTextModule,
            FgvInputEmailModule,
            FgvCardModule,
            CommonModule,
            FormsModule,
            ReactiveFormsModule,
            UtilsModule,
            CheckboxModule,
            AccordionModule,
            RouterModule
  ]
})
export class HomeAdmModule { }
