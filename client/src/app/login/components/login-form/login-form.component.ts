import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { faLock } from '@fortawesome/free-solid-svg-icons';
import { Account } from 'src/app/Core/models/Account.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  faLock = faLock;
  loginForm?: FormGroup;

  @Output() submitEvent = new EventEmitter<Account>();

  constructor(private fb: FormBuilder, private httpService: HttpService) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSubmit() {
    const body = {
      email: this.loginForm?.controls["email"].value,
      password: this.loginForm?.controls["password"].value,
    }

    this.httpService.post<Account>('Account/login', body).subscribe(response => { 
      this.submitEvent.emit(response);
    })
  }
}
