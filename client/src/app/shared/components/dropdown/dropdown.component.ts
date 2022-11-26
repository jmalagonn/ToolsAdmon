import { Component, Input } from '@angular/core';
import { DropdownItem } from 'src/app/Core/models/Dropdown-item.model';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent {
  @Input() label?: string;
  @Input() options?: DropdownItem[];

  onSelectOption(option: DropdownItem) {
    this.label = option.description;
  }
}
