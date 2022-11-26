import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { User } from 'src/app/Core/models/User.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-add-user-modal',
  templateUrl: './add-user-modal.component.html',
  styleUrls: ['./add-user-modal.component.scss']
})
export class AddUserModalComponent {
  addUserForm?: FormGroup;

  @Output() UserAddedEvent = new EventEmitter<User>();

  constructor(
    public bsModalRef: BsModalRef,
    public fb: FormBuilder,
    public httpService: HttpService
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.addUserForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  onSubmit() {
    const body = {
      name: this.addUserForm?.controls["name"].value
    };

    this.httpService.post<User>('Users/addEmployee', body).subscribe(User => {
      this.bsModalRef.hide();
      this.bsModalRef.onHide.emit(User);
    });
  }
}
