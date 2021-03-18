import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from '../shared/page-not-found/page-not-found.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileItemBuyComponent } from './profile-item-buy/profile-item-buy.component';
import { ProfileItemSearchComponent } from './profile-item-search/profile-item-search.component';
import { ProfileLandingComponent } from './profile-landing/profile-landing.component';
import { ProfileSearchComponent } from './profile-search/profile-search.component';
import { ProfilesComponent } from './profiles.component';

const routes: Routes = [
  {
    path: '', component: ProfilesComponent,
    children: [
      { path: '', component: ProfileLandingComponent },
      { path: 'profile/:id', component: ProfileDetailsComponent },
      { path: 'products/search', component: ProfileItemSearchComponent },
      { path: 'products/:id', component: ProfileItemBuyComponent },
      { path: 'search', component: ProfileSearchComponent },
      { path: 'post', loadChildren: () => import('./post/post.module').then(m => m.PostModule) },
      { path: '**', component: PageNotFoundComponent }
    ]
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfilesRoutingModule { }
