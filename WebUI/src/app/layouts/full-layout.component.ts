import { Component, OnInit } from '@angular/core';
import { NavigationService } from '../navigation.service';
import { NavItem } from '../nav-item';

@Component({
  selector: 'app-dashboard',
  templateUrl: './full-layout.component.html'
})
export class FullLayoutComponent implements OnInit {

  public disabled = false;
  public status: {isopen: boolean} = {isopen: false};

  constructor(public nav: NavigationService) {
  }

  public toggled(open: boolean): void {
    console.log('Dropdown is now: ', open);
  }

  public toggleDropdown($event: MouseEvent): void {
    $event.preventDefault();
    $event.stopPropagation();
    this.status.isopen = !this.status.isopen;
  }

  ngOnInit(): void {
    this.nav.selectedMenu = this.nav.navbar[0];
  }

  selectMenuItem(e: MouseEvent, menuItem: NavItem):void {
    this.nav.selectedMenu = menuItem;
    e.preventDefault();
  }
}
