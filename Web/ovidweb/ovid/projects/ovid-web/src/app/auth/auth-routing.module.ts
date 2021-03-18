import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from '../shared/page-not-found/page-not-found.component';

import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'signin', component: SignInComponent },
  { path: '', redirectTo: 'register', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
