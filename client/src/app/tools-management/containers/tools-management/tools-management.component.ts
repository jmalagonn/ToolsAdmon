import { ChangeDetectorRef, Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Tool } from 'src/app/Core/models/Tool.model';
import { HttpService } from 'src/app/services/http.service';
import { AddToolModalComponent } from '../../components/add-tool-modal/add-tool-modal.component';

@Component({
  selector: 'app-tools-management',
  templateUrl: './tools-management.component.html',
  styleUrls: ['./tools-management.component.scss']
})
export class ToolsManagementComponent implements OnInit {
  modalRef?: BsModalRef;
  tools?: Tool[];

  constructor(
    private modalService: BsModalService,
    private httpService: HttpService) { }

  ngOnInit(): void {
    this.getToolsList();
  }

  onOpenAddToolModal() {
    this.modalRef = this.modalService.show(AddToolModalComponent);

    if (this.modalRef?.onHide) {
      this.modalRef.onHide.subscribe((tool: Tool) => {
        if(!tool.toolGuid) return;

        this.getToolsList();
      });
    }
  }

  getToolsList(): void {
    this.httpService.get<Tool[]>('Tools').subscribe(response => this.tools = response);
  }
}
