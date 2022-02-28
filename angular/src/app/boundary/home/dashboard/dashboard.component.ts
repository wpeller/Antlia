import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  Component,
  Injector,
  OnInit
} from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  animations: [appModuleAnimation()]
})
export class DashboardComponent extends AppComponentBase implements OnInit {
  constructor(
    injector: Injector
  ) {
    super(injector);
  }

  ngOnInit() {
  }

}
