import { Component, Input, OnInit } from '@angular/core';
import { faCircleInfo, faPen, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Tool } from 'src/app/Core/models/Tool.model';

@Component({
  selector: 'app-tools-list',
  templateUrl: './tools-list.component.html',
  styleUrls: ['./tools-list.component.scss']
})
export class ToolsListComponent {  
  faPen = faPen;
  faTrash = faTrash;
  faCircleInfo = faCircleInfo;

  @Input() tools?: Tool[];  
}
