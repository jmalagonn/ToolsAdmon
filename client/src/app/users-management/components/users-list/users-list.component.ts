import { Component, Input } from '@angular/core';
import { User } from 'src/app/Core/models/User.model';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent {
  @Input() users?: User[];
}
