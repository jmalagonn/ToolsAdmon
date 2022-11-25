import { Component } from '@angular/core';
import { Account } from './Core/models/Account.model';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Administrador de Herramienta';

  constructor(private accountService: AccountService) {
    this.setCurrentAccount();
  }

  setCurrentAccount() {
    const account: Account = JSON.parse(localStorage.getItem('account')!);
    this.accountService.setCurrentAccount(account);
  }
}
