import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: "fgv-table-actions",
  templateUrl: "./fgv-table-actions.component.html",
  styleUrls: ["./fgv-table-actions.component.css"],
})
export class FgvTableActionsComponent {
//  @Input() acoes: Action[] = [];

  @Output() editar: EventEmitter<any> = new EventEmitter<any>();
  @Output() excluir: EventEmitter<any> = new EventEmitter<any>();

  editarHandler(event): void {
    this.editar.emit(event);
  }

  excluirHandler(event): void {
    this.excluir.emit(event);
  }

}
