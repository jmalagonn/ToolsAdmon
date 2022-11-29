import { Pipe, PipeTransform } from '@angular/core';
import { OutputToolState } from 'src/app/Core/models/Output-tool-state.model';

@Pipe({
  name: 'outputToolState'
})
export class OutputToolStatePipe implements PipeTransform {

  transform(value: OutputToolState, ...args: unknown[]): string {
    return value.outputToolStateId == 1
      ? "Abierto"
      : "Cerrado";
  }

}
