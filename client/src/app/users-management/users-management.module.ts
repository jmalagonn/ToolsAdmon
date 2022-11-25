import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersManagementRoutingModule } from './users-management-routing.module';
import { UsersManagementComponent } from './containers/users-management/users-management.component';
import { UsersListComponent } from './components/users-list/users-list.component';
import { AddUserModalComponent } from './components/add-user-modal/add-user-modal.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    UsersManagementComponent,
    UsersListComponent,
    AddUserModalComponent
  ],
  imports: [
    CommonModule,
    UsersManagementRoutingModule,
    SharedModule,
  ]
})
export class UsersManagementModule { }
