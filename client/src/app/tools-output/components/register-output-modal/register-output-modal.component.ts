import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Tool } from 'src/app/Core/models/Tool.model';
import { User } from 'src/app/Core/models/User.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-register-output-modal',
  templateUrl: './register-output-modal.component.html',
  styleUrls: ['./register-output-modal.component.scss']
})
export class RegisterOutputModalComponent implements OnInit {
  employees?: User[];
  tools?: Tool[];

  constructor(
    public bsModalRef: BsModalRef, 
    public httpService: HttpService) { } 

  ngOnInit(): void {
    this.getEmployees();
    this.getTools();
  }

  getEmployees() {
    this.httpService.get<User[]>('Users/employees').subscribe(employees => this.employees = employees);
  }

  getTools(): void {
    this.httpService.get<Tool[]>('Tools/available-tools').subscribe(tools => this.tools = tools);
  } 
}
