import { Pipe, PipeTransform } from '@angular/core';
import { DropdownItem } from 'src/app/Core/models/Dropdown-item.model';

@Pipe({
  name: 'toDropdownItem'
})
export class ToDropdownItemPipe implements PipeTransform {

  transform(values: any, ...args: string[]): DropdownItem[] {
    const idProperty = args[0];
    const descriptionProperty = args[1];

    return values.map((value: any) => ({
      id: value[idProperty],
      description: value[descriptionProperty]
    }));
  }

}
