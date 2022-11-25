import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ToolsManagementComponent } from './containers/tools-management/tools-management.component';

const routes: Routes = [
  {
    path: '',
    component: ToolsManagementComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ToolsManagementRoutingModule { }
