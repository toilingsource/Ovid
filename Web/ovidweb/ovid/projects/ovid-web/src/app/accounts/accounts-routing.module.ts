import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from '../shared/page-not-found/page-not-found.component';
import { AccountHomeComponent } from './account-home/account-home.component';

import { AccountsComponent } from './accounts.component';

const routes: Routes = [
  {
    path: '', component: AccountsComponent,
    children: [
      { path: '', component: AccountHomeComponent },
      { path: 'links', loadChildren: () => import('./links/links.module').then(m => m.LinksModule) },
      { path: 'socialmedia', loadChildren: () => import('./social-media/social-media.module').then(m => m.SocialMediaModule) },
      { path: 'rep', loadChildren: () => import('./reputation/reputation.module').then(m => m.ReputationModule) },
      { path: '**', component: PageNotFoundComponent }
    ]
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsRoutingModule { }
