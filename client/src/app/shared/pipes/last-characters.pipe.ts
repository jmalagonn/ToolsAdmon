import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'lastCharacters'
})
export class LastCharactersPipe implements PipeTransform {

  transform(value: string, length: number): string {
    return value.slice(length * -1);
  }

}
