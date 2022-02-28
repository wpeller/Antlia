import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvInputSelectModule } from '../fgv-input-select/fgv-input-select.module';
import { FgvReportViewerComponent } from './fgv-report-viewer.component';
import { PdfJsViewerModule } from 'ng2-pdfjs-viewer';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FgvInputSelectModule,
        PdfJsViewerModule
    ],
    declarations: [FgvReportViewerComponent],
    exports: [FgvReportViewerComponent],
    bootstrap: [FgvReportViewerComponent]
})
export class FgvReportViewerModule { }
