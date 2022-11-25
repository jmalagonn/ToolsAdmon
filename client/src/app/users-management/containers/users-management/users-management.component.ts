import { Component } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { User } from 'src/app/Core/models/User.model';
import { HttpService } from 'src/app/services/http.service';
import { AddUserModalComponent } from '../../components/add-user-modal/add-user-modal.component';

@Component({
  selector: 'app-users-management',
  templateUrl: './users-management.component.html',
  styleUrls: ['./users-management.component.scss']
})
export class UsersManagementComponent {
  modalRef?: BsModalRef;
  users?: User[];

  constructor(
    private modalService: BsModalService,
    private httpService: HttpService) { }

  ngOnInit(): void {
    // this.getUsersList();
  }

  onOpenAddUserModal() {
    this.modalRef = this.modalService.show(AddUserModalComponent);

    if (this.modalRef?.onHide) {
      this.modalRef.onHide.subscribe((user: User) => {
        if(!user.idCard) return;

        this.getUsersList();
      });
    }
  }

  getUsersList(): void {
    this.httpService.get<User[]>('Users').subscribe(response => this.users = response);
  }
}
