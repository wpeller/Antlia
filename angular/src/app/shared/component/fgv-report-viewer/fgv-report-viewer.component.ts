import { Component, EventEmitter, Injector, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectItem } from 'primeng/api';
import { GenericItem } from '../GenericItem';

@Component({
    selector: 'fgv-report-viewer',
    templateUrl: './fgv-report-viewer.component.html',
    styleUrls: ['./fgv-report-viewer.component.css'],
})
export class FgvReportViewerComponent implements OnInit {
    formulario: FormGroup;

    @ViewChild('pdfViewerAutoLoad') pdfViewerAutoLoad;

    @Input() downloadFileName: string = 'relatório-fgv';
    @Input() pdfViewer: any = null;
    @Input() reportHeight: number = 600;
    @Input() exibirExportar: boolean = false;
    @Input() formatos: SelectItem[] = [];

    @Output() onChangeExport: EventEmitter<string> = new EventEmitter<string>();

    constructor(
        private injector: Injector,
        private build: FormBuilder) {
        this.gerarFormulario();
    }

    ngOnInit() {
        this.getFormatos();

        if (this.pdfViewer != null) {
            this.load(this.pdfViewer);
        }
    }

    gerarFormulario(): void {
        this.formulario = this.build.group({
            formato: ['']
        });
    }

    onChangeExportHandler(value: string): void {
        this.onChangeExport.emit(value);
    }

    getFormatos(): void {

        if (this.formatos != null && this.formatos.length > 0) {
            return;
        }

        if (this.formatos == null) {
            this.formatos = [];
        }

        this.formatos.push(new GenericItem('PDF', '0'));
        this.formatos.push(new GenericItem('EXCEL', '1'));
        this.formatos.push(new GenericItem('WORD', '2'));
        this.formatos.push(new GenericItem('EXCEL OPEN XML', '3'));
        this.formatos.push(new GenericItem('POWER POINT', '4'));
        this.formatos.push(new GenericItem('TIFF', '5'));
        this.formatos.push(new GenericItem('MHTML', '6'));
        this.formatos.push(new GenericItem('CSV', '7'));
        this.formatos.push(new GenericItem('XML', '8'));
        this.formatos.push(new GenericItem('ATOMSVC', '9'));
    }

    load(_pdfViewer: any): void {

        this.pdfViewer = _pdfViewer;

        if (this.pdfViewerAutoLoad == null || _pdfViewer == null) {
            return;
        }

        this.pdfViewerAutoLoad.pdfSrc = _pdfViewer; // pdfSrc can be Blob or Uint8Array
        this.pdfViewerAutoLoad.refresh(); // Ask pdf viewer to load/refresh pdf
    }
}
