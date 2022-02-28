import { BsDropdownModule } from 'ngx-bootstrap';
import { DropdownModule } from 'primeng/primeng';
import { FgvTableActionsCustomComponent } from './fgv-table-actions-custom.component';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [BsDropdownModule.forRoot(), DropdownModule],
    declarations: [FgvTableActionsCustomComponent],
    exports: [FgvTableActionsCustomComponent],
    bootstrap: [FgvTableActionsCustomComponent],
})
export class FgvTableActionsCustomModule { }
