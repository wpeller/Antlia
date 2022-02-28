import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'fgv-badge',
    templateUrl: './fgv-badge.component.html',
    styleUrls: ['./fgv-badge.component.css'],
})
export class FgvBadgeComponent implements OnInit {
    @Input() badgeText: string = '';
    @Input() badgeStyle: string = '';
    @Input() badgeClass: string = '';

    constructor() {
    }

    ngOnInit() {
        let _text = this.badgeText.toUpperCase();

        if (_text == 'BLOQUEADO') {
            this.getBloqueado();
        } else if (_text == 'ATIVO') {
            this.getAtivo();
        } else {
            this.getDefault();
        }
    }

    getDefault(): void {
        this.badgeClass += 'badge badge-primary';
    }

    getBloqueado(): void {
        this.badgeText = 'Bloqueado';
        this.badgeClass += 'badge badge-danger';
    }

    getAtivo(): void {
        this.badgeText = 'Ativo';
        this.badgeClass += 'badge badge-primary';
    }
}
