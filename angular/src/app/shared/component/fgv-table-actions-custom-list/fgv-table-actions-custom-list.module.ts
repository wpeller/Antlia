import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { FgvTableActionsCustomListComponent } from './fgv-table-actions-custom-list.component';

@NgModule({
    imports: [BsDropdownModule.forRoot(), DropdownModule],
    declarations: [FgvTableActionsCustomListComponent],
    exports: [FgvTableActionsCustomListComponent],
    bootstrap: [FgvTableActionsCustomListComponent],
})
export class FgvTableActionsCustomListModule { }
