import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfilesRoutingModule } from './profiles-routing.module';
import { ProfilesComponent } from './profiles.component';
import { ProfileLandingComponent } from './profile-landing/profile-landing.component';
import { ProfileSearchComponent } from './profile-search/profile-search.component';
import { ProfileItemSearchComponent } from './profile-item-search/profile-item-search.component';
import { ProfileItemBuyComponent } from './profile-item-buy/profile-item-buy.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileNavComponent } from './profile-nav/profile-nav.component';


@NgModule({
  declarations: [
    ProfilesComponent, 
    ProfileLandingComponent, 
    ProfileSearchComponent, 
    ProfileItemSearchComponent, 
    ProfileItemBuyComponent,
    ProfileDetailsComponent,
    ProfileNavComponent,
    
  ],
  imports: [
    CommonModule,
    ProfilesRoutingModule
  ]
})
export class ProfilesModule { }
