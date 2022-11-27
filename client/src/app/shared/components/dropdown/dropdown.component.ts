import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DropdownItem } from 'src/app/Core/models/Dropdown-item.model';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent {
  selectedOption?: DropdownItem;

  @Input() label?: string;
  @Input() options?: DropdownItem[];
  
  @Output() onSelectOptionEvent = new EventEmitter<DropdownItem>(); 

  onSelectOption(option: DropdownItem) {
    this.label = option.description;
    this.onSelectOptionEvent.emit(option);
  }
}
