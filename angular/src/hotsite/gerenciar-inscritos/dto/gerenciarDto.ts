import { InscritoDto } from "./inscritoDto";

export class GerenciarInscritosDto{
    turma: string;    
    inscritos: InscritoDto[];
    isOpen: boolean
    
    constructor() {
        this.isOpen = false;
    }

}
