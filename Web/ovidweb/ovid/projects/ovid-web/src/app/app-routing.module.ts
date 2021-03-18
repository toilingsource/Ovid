import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'profiles', loadChildren: () => import('./profiles/profiles.module').then(m => m.ProfilesModule) },
  { path: 'account', loadChildren: () => import('./accounts/accounts.module').then(m => m.AccountsModule) },
  { path: 'tools', loadChildren: () => import('./tools/tools.module').then(m => m.ToolsModule) },
  { path: 'home', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
