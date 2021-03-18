import { CommonModule } from '@angular/common';
import { LocalStorageService } from './services/local-storage.service';
import { ConfigService } from './services/config.service';
import { AuthService } from './services/auth.service';
import { NgModule, Component } from '@angular/core';
import { OAuthModule } from 'angular-oauth2-oidc';
import { RouterModule, Routes } from '@angular/router';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    OAuthModule.forRoot(),
  ],
  providers:[
    AuthService,
    ConfigService,
    LocalStorageService,
  ],
  exports: [
    OAuthModule,
    RouterModule,
  ]
})
export class OvidAuthModule { }
