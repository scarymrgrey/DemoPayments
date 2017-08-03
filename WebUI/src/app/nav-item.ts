import { NavMenu } from './nav-menu';
export class NavItem {

  isSelected: boolean;
  _subMenu: NavMenu[];

  constructor(public title: string, ...subMenu: NavMenu[])
  {
    this._subMenu = subMenu;
    let activeFound = false;
    let firstNavItem: NavItem;
    for (let subMenuItem of subMenu) {
      for (let item of subMenuItem.items) {
        if (!firstNavItem)
          firstNavItem = item;
        if (item.isSelected) {
          activeFound = true;
          break;
        }
      }
      if (activeFound)
        break;
    }
    if (!activeFound && firstNavItem)
      firstNavItem.isSelected = true;
  }

  get subMenu(): NavMenu[] {
    return this._subMenu;
  }

  setSelectedSubItem(subItem: NavItem) {
    for (let subMenuItem of this.subMenu)
      for (let item of subMenuItem.items)
        item.isSelected = false;
    subItem.isSelected = true;
  }

  toggle(): void {
    this.isSelected = !this.isSelected;
  }
}
