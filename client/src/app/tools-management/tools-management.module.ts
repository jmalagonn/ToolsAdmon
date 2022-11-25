import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ToolsManagementRoutingModule } from './tools-management-routing.module';
import { ToolsManagementComponent } from './containers/tools-management/tools-management.component';
import { SharedModule } from '../shared/shared.module';
import { AddToolModalComponent } from './components/add-tool-modal/add-tool-modal.component';
import { ToolsListComponent } from './components/tools-list/tools-list.component';


@NgModule({
  declarations: [
    ToolsManagementComponent,
    AddToolModalComponent,
    ToolsListComponent
  ],
  imports: [
    CommonModule,
    ToolsManagementRoutingModule,
    SharedModule,
  ]
})
export class ToolsManagementModule { }
