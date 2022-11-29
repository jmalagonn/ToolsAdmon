import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OutputTool } from 'src/app/Core/models/Output-tool.model';
import { HttpService } from 'src/app/services/http.service';
import { RegisterOutputModalComponent } from '../../components/register-output-modal/register-output-modal.component';

@Component({
  selector: 'app-tools-output',
  templateUrl: './tools-output.component.html',
  styleUrls: ['./tools-output.component.scss']
})
export class ToolsOutputComponent implements OnInit {
  modalRef?: BsModalRef;
  outputToolsRegisters?: OutputTool[];
  openOutputTools?: OutputTool[];
  closedOutputTools?: OutputTool[];

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
    this.httpService.get<OutputTool[]>('OutputTools').subscribe(response => {
      this.outputToolsRegisters = response
      this.openOutputTools = this.outputToolsRegisters.filter(outputTool => outputTool.outputToolState.outputToolStateName == "Open");
      this.closedOutputTools = this.outputToolsRegisters.filter(outputTool => outputTool.outputToolState.outputToolStateName != "Open");
    });
  }
}
