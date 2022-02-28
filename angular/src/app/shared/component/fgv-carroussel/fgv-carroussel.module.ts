import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FgvCarrousselComponent } from './fgv-carroussel.component';
import { CarouselModule } from 'ngx-bootstrap';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        CarouselModule.forRoot()
    ],
    declarations: [FgvCarrousselComponent],
    exports: [FgvCarrousselComponent],
    bootstrap: [FgvCarrousselComponent],
})
export class FgvCarrousselModule { }
