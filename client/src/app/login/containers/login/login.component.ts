import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Account } from 'src/app/Core/models/Account.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private accountService: AccountService, private router: Router) {}
  
  onLogin(account: Account) {
    this.accountService.login(account);
    this.router.navigateByUrl('/');
  }
}
