import { Component, EventEmitter, Input, Output } from '@angular/core';
import { faCircleInfo, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Tool } from 'src/app/Core/models/Tool.model';

@Component({
  selector: 'app-selected-tools-list',
  templateUrl: './selected-tools-list.component.html',
  styleUrls: ['./selected-tools-list.component.scss']
})
export class SelectedToolsListComponent {
  faTrash = faTrash;
  faCircleInfo = faCircleInfo;
  
  @Input() tools?: Tool[];

  @Output() deleteToolEvent = new EventEmitter<Tool>();

  onDeleteTool(toBeDeleted: Tool): void {
    this.deleteToolEvent.emit(toBeDeleted);
  } 
}
