import { Component, Input } from '@angular/core';
import { OutputTool } from 'src/app/Core/models/Output-tool.model';
import { faCircleInfo } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-open-tools-output-list',
  templateUrl: './open-tools-output-list.component.html',
  styleUrls: ['./open-tools-output-list.component.scss']
})
export class OpenToolsOutputListComponent {
  faCircleInfo = faCircleInfo;

  @Input() outputTools?: OutputTool[]; 
}
