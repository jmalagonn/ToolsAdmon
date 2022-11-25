import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { Account } from '../Core/models/Account.model';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentAccountSource = new ReplaySubject<Account | null>(1);
  currentAccount$ = this.currentAccountSource.asObservable();

  constructor(private router: Router) { }

  login(account: Account): void {
    if(!account) return;
          
    this.setCurrentAccount(account);
  }

  setCurrentAccount(account: Account) {    
    localStorage.setItem('account', JSON.stringify(account));
    this.currentAccountSource.next(account);
  }

  logout() {
    localStorage.removeItem('account');
    this.currentAccountSource.next(null);
    this.router.navigateByUrl("login");
  }
}
