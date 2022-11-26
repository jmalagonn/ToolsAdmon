import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ToolsOutputComponent } from './containers/tools-output/tools-output.component';

const routes: Routes = [
  {
    path: '',
    component: ToolsOutputComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ToolsOutputRoutingModule { }
