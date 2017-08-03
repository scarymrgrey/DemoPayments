import { Component } from '@angular/core';
import { DataService } from './data.service';
import { NavigationService } from './navigation.service';

@Component({
  // tslint:disable-next-line
  selector: 'body',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent {
}
