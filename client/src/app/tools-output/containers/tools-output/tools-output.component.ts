import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToolsOutput } from 'src/app/Core/models/Tools-output.model';
import { HttpService } from 'src/app/services/http.service';
import { RegisterOutputModalComponent } from '../../components/register-output-modal/register-output-modal.component';

@Component({
  selector: 'app-tools-output',
  templateUrl: './tools-output.component.html',
  styleUrls: ['./tools-output.component.scss']
})
export class ToolsOutputComponent implements OnInit {
  modalRef?: BsModalRef;
  outputToolsRegisters?: ToolsOutput[];

  constructor(
    private modalService: BsModalService,
    private httpService: HttpService) { }

  ngOnInit(): void {
    this.getOutputToolsRegisters();
  }

  onOpenAddToolModal() {
    this.modalRef = this.modalService.show(RegisterOutputModalComponent);
  }

  getOutputToolsRegisters(): void {
    this.httpService.get<ToolsOutput[]>('OutputTools').subscribe(response => this.outputToolsRegisters = response);
  }
}
