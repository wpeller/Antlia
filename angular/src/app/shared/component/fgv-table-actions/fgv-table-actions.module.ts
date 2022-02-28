import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { FgvTableActionButtonModule } from '../fgv-table-action-button/fgv-table-action-button.module';
import { FgvTableActionContentModule } from '../fgv-table-action-content/fgv-table-action-content.module';
import { FgvTableActionsComponent } from './fgv-table-actions.component';

@NgModule({
    imports: [
        BsDropdownModule.forRoot(),
        DropdownModule,
        FgvTableActionButtonModule,
        FgvTableActionContentModule
    ],
	declarations: [ FgvTableActionsComponent ],
	exports: [ FgvTableActionsComponent ],
	bootstrap: [ FgvTableActionsComponent ],
})
export class FgvTableActionsModule {}
