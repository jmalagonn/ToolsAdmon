import { Component, EventEmitter, Input, Output } from '@angular/core';
import { faCircleInfo, faPlus } from '@fortawesome/free-solid-svg-icons';
import { Tool } from 'src/app/Core/models/Tool.model';

@Component({
  selector: 'app-available-tools-list',
  templateUrl: './available-tools-list.component.html',
  styleUrls: ['./available-tools-list.component.scss']
})
export class AvailableToolsListComponent {
  faPlus = faPlus;
  faCircleInfo = faCircleInfo;

  @Input() tools?: Tool[];

  @Output() selectToolEvent = new EventEmitter<Tool>();

  onSelectTool(selectedTool: Tool): void {
    this.selectToolEvent.emit(selectedTool);
  } 
}
