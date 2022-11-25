import { Component } from '@angular/core';
import { AppConstants } from 'src/app/Core/constants/app-constants';

@Component({
  selector: 'app-dashboard-options',
  templateUrl: './dashboard-options.component.html',
  styleUrls: ['./dashboard-options.component.scss']
})
export class DashboardOptionsComponent {
  appConstants = AppConstants;

  constructor() {}
}
