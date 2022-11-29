import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { DropdownItem } from 'src/app/Core/models/Dropdown-item.model';
import { Tool } from 'src/app/Core/models/Tool.model';
import { OutputTool } from 'src/app/Core/models/Output-tool.model';
import { User } from 'src/app/Core/models/User.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-register-output-modal',
  templateUrl: './register-output-modal.component.html',
  styleUrls: ['./register-output-modal.component.scss']
})
export class RegisterOutputModalComponent implements OnInit {
  employees?: User[];
  availableTools: Tool[] = [];
  selectedTools:Tool[] = [];
  registerOutputForm?: FormGroup;
  responsible?: User;

  constructor(
    public bsModalRef: BsModalRef, 
    public httpService: HttpService,
    private fb: FormBuilder) { } 

  ngOnInit(): void {
    this.initForm();
    this.getEmployees();
    this.getTools();
  }

  getEmployees(): void {
    this.httpService.get<User[]>('Users/employees').subscribe(employees => this.employees = employees);
  }

  getTools(): void {
    this.httpService.get<Tool[]>('Tools/available-tools').subscribe(tools => this.availableTools = tools);
  } 

  onSelectTool(selectedTool: Tool): void {
    this.availableTools = this.availableTools?.filter(tool => tool.toolId != selectedTool.toolId);
    this.selectedTools?.push(selectedTool);    
    this.registerOutputForm!.controls["tools"].patchValue(this.selectedTools);  
  }

  onDeleteTool(toBeDeleted: Tool): void {
    this.selectedTools = this.selectedTools.filter(tool => tool.toolId != toBeDeleted.toolId);
    this.availableTools!.push(toBeDeleted);
    this.registerOutputForm!.controls["tools"].patchValue(this.selectedTools);
  }

  initForm() {
    this.registerOutputForm = this.fb.group({
      responsible: [null, Validators.required],
      tools: [null, Validators.required]
    });
  }

  registerOutput(): void {
    this.httpService.post<OutputTool>('OutputTools', this.registerOutputForm?.value)
      .subscribe(response => {
        this.bsModalRef.hide();
        console.log(response)
      });
  }

  onSelectResponsible(user: DropdownItem): void {
    this.responsible = this.employees!.find(e => e.userId == user.id);
    this.registerOutputForm!.controls["responsible"].setValue({...this.responsible});
  }
}
