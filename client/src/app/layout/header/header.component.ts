import { Component } from '@angular/core';
import { AppConstants } from 'src/app/Core/constants/app-constants';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  appConstants = AppConstants;
  
  constructor(private accountService: AccountService) {}

  onLogout() {
    this.accountService.logout();
  }
}
