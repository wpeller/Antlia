import { Component, Input } from '@angular/core';

@Component({
    selector: 'fgv-table-action-content',
    templateUrl: './fgv-table-action-content.component.html',
    styleUrls: ['./fgv-table-action-content.component.css']
})
export class FgvTableActionContentComponent {
    @Input() titulo: string = '';
    @Input() zindex: number = 5000;

    onClickMenu(): void {
        setTimeout(() => { this.setZindexMenu(); }, 100);
    }

    private setZindexMenu(): void {

        var elemento = document.getElementsByTagName('bs-dropdown-container');

        if (elemento == null || elemento.length <= 0) {
            setTimeout(() => { this.setZindexMenu(); }, 50);
            return;
        }

        for (var i = 0; i < elemento.length; i++) {
            elemento[i].attributes['style'].value += 'z-index:' + this.zindex;
        }
    }
}
