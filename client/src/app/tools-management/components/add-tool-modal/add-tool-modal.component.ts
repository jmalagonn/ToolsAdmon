import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Tool } from 'src/app/Core/models/Tool.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-add-tool-modal',
  templateUrl: './add-tool-modal.component.html',
  styleUrls: ['./add-tool-modal.component.scss']
})
export class AddToolModalComponent implements OnInit {
  addToolForm?: FormGroup;

  @Output() toolAddedEvent = new EventEmitter<Tool>();

  constructor(
    public bsModalRef: BsModalRef,
    public fb: FormBuilder,
    public httpService: HttpService
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.addToolForm = this.fb.group({
      toolName: ['', Validators.required]
    });
  }

  onSubmit() {
    const body = {
      toolName: this.addToolForm?.controls["toolName"].value
    };

    this.httpService.post<Tool>('Tools', body).subscribe(tool => {
      this.bsModalRef.hide();
      this.bsModalRef.onHide.emit(tool);
    });
  }
}

