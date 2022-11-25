import { Component } from '@angular/core';
import { faScrewdriverWrench, faToolbox, faUserGroup, faUserPen } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-dashboard-options',
  templateUrl: './dashboard-options.component.html',
  styleUrls: ['./dashboard-options.component.scss']
})
export class DashboardOptionsComponent {
  faToolbox = faToolbox;
  faScrewdriverWrench = faScrewdriverWrench;
  faUserGroup = faUserGroup;
  faUserPen = faUserPen;
}
