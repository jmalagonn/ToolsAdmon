import { Component } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RegisterOutputModalComponent } from '../../components/register-output-modal/register-output-modal.component';

@Component({
  selector: 'app-tools-output',
  templateUrl: './tools-output.component.html',
  styleUrls: ['./tools-output.component.scss']
})
export class ToolsOutputComponent {
  modalRef?: BsModalRef;

  constructor(private modalService: BsModalService) { }

  onOpenAddToolModal() {
    this.modalRef = this.modalService.show(RegisterOutputModalComponent);
  }
}
