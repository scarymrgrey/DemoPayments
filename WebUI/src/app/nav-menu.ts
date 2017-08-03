import { NavItem } from './nav-item';

export class NavMenu {

  private _items: NavItem[];
  private _isOpen: boolean;

  constructor(public title: string, ...items: NavItem[]) {
    this._items = items;
    this.isOpen = true;
  }

  get items(): NavItem[] {
    return this._items;
  }

  get isOpen():boolean {
    return this._isOpen;
  }

  set isOpen(value: boolean) {
    this._isOpen = value;
  }
}
