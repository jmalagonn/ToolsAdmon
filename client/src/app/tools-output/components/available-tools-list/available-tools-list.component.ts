import { Component, Input } from '@angular/core';
import { Tool } from 'src/app/Core/models/Tool.model';

@Component({
  selector: 'app-available-tools-list',
  templateUrl: './available-tools-list.component.html',
  styleUrls: ['./available-tools-list.component.scss']
})
export class AvailableToolsListComponent {
  @Input() tools?: Tool[];
}
