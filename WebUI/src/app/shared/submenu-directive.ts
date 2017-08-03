import { Directive, HostListener, ElementRef, Input } from '@angular/core';
import { NavMenu } from '../nav-menu';

@Directive({
  selector: '[subMenu]'
})
export class SubMenuDirective {

  constructor(private el: ElementRef) { }

  @Input('subMenu') subMenu: NavMenu;

  toggle() {
    this.subMenu.isOpen = !this.subMenu.isOpen;
  }
}

/**
* Allows the dropdown to be toggled via click.
*/
@Directive({
  selector: '[subMenuToggle]'
})
export class SubMenuToggleDirective {
  constructor(private subMenu: SubMenuDirective) {}

  @HostListener('click', ['$event'])
  toggleOpen($event: any) {
    $event.preventDefault();
    this.subMenu.toggle();
  }
}

export const SUBMENU_DIRECTIVES = [SubMenuDirective, SubMenuToggleDirective];
