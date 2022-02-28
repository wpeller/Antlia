import { Pipe, PipeTransform } from '@angular/core';
import { GerenciarInscritosDto } from './gerenciar-inscritos/dto/gerenciarDto';

@Pipe({
  name: 'matchesTurma'
})
export class MatchesTurmaPipe implements PipeTransform {

    transform(items: Array<any>, turma: string): Array<any> {
        if (!items || !turma) {
            return items;
        }
        return items.filter(item => item.turma === turma);
    }
}
