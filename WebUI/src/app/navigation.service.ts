import { Injectable } from '@angular/core';
import { NavItem } from './nav-item';
import { NavMenu } from './nav-menu';

@Injectable()
export class NavigationService {

  private readonly navigation = [
    new NavItem("MY",
      new NavMenu("My",
        new NavItem("Tasks"),
        new NavItem("Favorites"))),
    new NavItem("DATA ENTER",
      new NavMenu("Enter",
        new NavItem("Lenders"),
        new NavItem("Loans"),
        new NavItem("Insurances"),
        new NavItem("CPI Certificats"),
        new NavItem("Claims"),
        new NavItem("Carriers"),
        new NavItem("Master Policies")),
      new NavMenu("Manage",
        new NavItem("Lenders"),
        new NavItem("Loans"),
        new NavItem("Insurances"),
        new NavItem("CPI Certificats"),
        new NavItem("Claims"),
        new NavItem("Carriers"),
        new NavItem("Master Policies")),
      new NavMenu("Configure",
        new NavItem("Master Lenders"),
        new NavItem("Adjusters"))),
    new NavItem("PROCESSING",
      new NavMenu("Import",
        new NavItem("Loans"),
        new NavItem("Payments"),
        new NavItem("Claims")),
      new NavMenu("Export",
        new NavItem("Loans"),
        new NavItem("Claims"),
        new NavItem("CPI Certificates")),
      new NavMenu("To Process",
        new NavItem("CPI Certificates"),
        new NavItem("Insurances"),
        new NavItem("Documents"),
        new NavItem("Loans"),
        new NavItem("Claims"),
        new NavItem("Incoming Documents")),
      new NavMenu("Verification Tools",
        new NavItem("State Farm"),
        new NavItem("Geico"),
        new NavItem("All State"),
        new NavItem("Progressive"),
        new NavItem("USAA"),
        new NavItem("Farmers"),
        new NavItem("Liberty Mutual"),
        new NavItem("Nationwide"),
        new NavItem("American Family"),
        new NavItem("Travelers"),
        new NavItem("Vehicle History"))),
    new NavItem("REPORTS",
        new NavMenu("Internal",
          new NavItem("Admin Fee"),
          new NavItem("Aged Premium"),
          new NavItem("Agency"),
          new NavItem("Balance Exception"),
          new NavItem("Bank Update"),
          new NavItem("Bank Cycle"),
          new NavItem("Cleared Notices and Certificates")),
        new NavMenu("Lender",
          new NavItem("Waive List Report"),
          new NavItem("MAS 90 A/R Statement"),
          new NavItem("Agregate"),
          new NavItem("ST Audit"),
          new NavItem("Bankrupcy"),
          new NavItem("Cancellation"),
          new NavItem("SPC Cancellation"),
          new NavItem("VIS Cancellation"),
          new NavItem("Generated Certificates"),
          new NavItem("SPC Generated Certificates"),
          new NavItem("Detailed Interest"),
          new NavItem("Duplicate Coverage"),
          new NavItem("Loan Status"),
          new NavItem("Renewal")),
        new NavMenu("Claims",
          new NavItem("Aged"),
          new NavItem("Loss"),
          new NavItem("Open"),
          new NavItem("Process Issued")),
        new NavMenu("Cash",
          new NavItem("Premium Invoice")),
        new NavMenu("Commission",
          new NavItem("Agent"),
          new NavItem("Favorites")),
        new NavMenu("Configuration",
          new NavItem("Reports Editor"),
          new NavItem("Reports List"))),
    new NavItem("ADMINISTRATION",
        new NavMenu("Enter",
          new NavItem("Mail Boxes"),
          new NavItem("Email Templates"),
          new NavItem("Import Templates"),
          new NavItem("Users"),
          new NavItem("Roles")),
        new NavMenu("Manage",
          new NavItem("Mail Boxes"),
          new NavItem("Email Templates"),
          new NavItem("Import Templates"),
          new NavItem("Export Templates"),
          new NavItem("Users"),
          new NavItem("Roles")),
        new NavMenu("Audit",
          new NavItem("By Users"),
          new NavItem("By Screen")))
  ];

  private _selectedMenu: NavItem;

  constructor() {}

  public get navbar(): NavItem[] {
    return this.navigation;
  }

  public get selectedMenu(): NavItem {
    return this._selectedMenu;
  }

  public set selectedMenu(item: NavItem) {
    if (this._selectedMenu)
      this._selectedMenu.isSelected = false;
    this._selectedMenu = item;
    this._selectedMenu.isSelected = true;
  }
}
