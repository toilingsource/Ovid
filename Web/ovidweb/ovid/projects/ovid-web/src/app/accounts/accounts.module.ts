import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsRoutingModule } from './accounts-routing.module';
import { AccountsComponent } from './accounts.component';
import { AccountHomeComponent } from './account-home/account-home.component';
import { AccountNavComponent } from './account-nav/account-nav.component';


@NgModule({
  declarations: [AccountsComponent, AccountHomeComponent, AccountNavComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule
  ]
})
export class AccountsModule { }
