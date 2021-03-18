import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignInDialogComponent } from './sign-in-dialog/sign-in-dialog.component';


@NgModule({
  declarations: [RegisterComponent, SignInComponent, SignInDialogComponent],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
