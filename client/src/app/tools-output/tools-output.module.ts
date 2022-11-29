import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ToolsOutputRoutingModule } from './tools-output-routing.module';
import { ToolsOutputComponent } from './containers/tools-output/tools-output.component';
import { RegisterOutputModalComponent } from './components/register-output-modal/register-output-modal.component';
import { SharedModule } from '../shared/shared.module';
import { AvailableToolsListComponent } from './components/available-tools-list/available-tools-list.component';
import { SelectedToolsListComponent } from './components/selected-tools-list/selected-tools-list.component';
import { OpenToolsOutputListComponent } from './components/open-tools-output-list/open-tools-output-list.component';
import { ToolsOutputDetailComponent } from './containers/tools-output-detail/tools-output-detail.component';


@NgModule({
  declarations: [
    ToolsOutputComponent,
    RegisterOutputModalComponent,
    AvailableToolsListComponent,
    SelectedToolsListComponent,
    OpenToolsOutputListComponent,
    ToolsOutputDetailComponent
  ],
  imports: [
    CommonModule,
    ToolsOutputRoutingModule,
    SharedModule
  ]
})
export class ToolsOutputModule { }
