import { Injectable } from '@angular/core';
import { Subject, Observable, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AccessToken } from '../models/access-token.model';
import { OAuthErrorEvent, OAuthService } from 'angular-oauth2-oidc';
import { map, mergeMap, take } from 'rxjs/operators';
import { JwtHelper } from './jwt-helper';
import jwt_decode from "jwt-decode";

import { ApplicationUser } from '../models/application-user.model';
import { UserProfile } from '../models/user-profile.model';
import { ConfigService } from './config.service';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {6

  private readonly _discoveryDocUrl: string = '/.well-known/openid-configuration';

  private get discoveryDocUrl() { return this.config.AuthenticationServer + this._discoveryDocUrl; }


  public loginRedirectUrl: string;
  public logoutRedirectUrl: string;

  public reLoginDelegate: () => void;

  private previousIsLoggedInCheck = false;
  private _loginStatus: Subject<boolean> = new Subject();
  private _userUpdated: Subject<ApplicationUser> = new Subject();
  private _currentUser: UserProfile = null;

  /** Update User Status */
  get updateUserStatus(): Observable<ApplicationUser> {
    return this._userUpdated.asObservable();
  }

  constructor(private http: HttpClient,
    private config: ConfigService,
    private router: Router,
    private store: LocalStorageService,
    private oauth: OAuthService) {

    // get current user from application storage
    this._currentUser = this.store.CurrentUser;
    this.initializeOdicService();
    this.reevaluateLogin();
  }

    private initializeOdicService() {
    this.oauth.issuer = this.config.AuthenticationServer; 
    this.oauth.clientId = 'themis_spa';
    this.oauth.scope = 'openid email phone profile offline_access roles';
    this.oauth.skipSubjectCheck = true;
    this.oauth.requireHttps = false;
    this.oauth.dummyClientSecret = 'not_used';
    this.oauth.setupAutomaticSilentRefresh();

    this.oauth.events.subscribe(event=>{
      if(event instanceof OAuthErrorEvent){
        this.signOut();
        this.router.navigate(['/auth/signin']);
      }
    })

    this.oauth.setStorage(localStorage);
  }

  /** Is the User Logged In */
  public isLoggedInStatus(): Observable<boolean> {
    return this._loginStatus.asObservable();
  }

  /** is Logged In */
  public get isLoggedIn(): boolean {
    return (this._currentUser == null) ? false : true;
  }

  /** The Current Application User Subject */
  public get currentUser(): UserProfile {
    if (this._currentUser == null) {
      this._currentUser = this.store.CurrentUser;
      this.reevaluateLogin();
    }
    return this._currentUser;
  }

 
  /**
   * User Email Address
   *
   * @readonly
   * @type {string}
   * @memberof AuthService
   */
  public get EmailAddress():string{
    if(this.currentUser == null){
      return '';
    }
    return (this.currentUser.emailAddress.length > 4)?this.currentUser.emailAddress:'';
  }

  /** The Current Auth Token Expiry */
  public get accessTokenExpiryDate(): Date {
    return new Date(this.oauth.getAccessTokenExpiration());
  }

  /** Get Current Access Token */
  public get AccessToken(): string {
    return this.oauth.getAccessToken();
  }

  /** Is Session Expired */
  public get isSessionExpired(): boolean {
    if (this.accessTokenExpiryDate == null) {
      return true;
    }
    return this.accessTokenExpiryDate.valueOf() <= new Date().valueOf();
  }

  /** Get Refresh Token */
  public get refreshToken(): string {
    return this.oauth.getRefreshToken();
  }

  /**
   * Sign User In
   * @param username username
   * @param password Password
   * @param rememberMe rememberer user?
   */
  public signIn(username: string, password: string, rememberMe?: boolean) {
    if (this.isLoggedIn) {
      this.signOut();
    }
    this.initializeOdicService();

    return from(this.oauth.loadDiscoveryDocument(this.discoveryDocUrl)).pipe(mergeMap(() => {
      return from(this.oauth.fetchTokenUsingPasswordFlow(username, password)).pipe(
        map(() => this.processLoginResponse(this.oauth.getAccessToken(), rememberMe))
      );
    }));
  }

  /** Refresh Login */
  public refreshLogin(): Observable<ApplicationUser> {
    if (this.oauth.discoveryDocumentLoaded) {
      return from(this.oauth.refreshToken()).pipe(
        map(() => this.processLoginResponse(this.oauth.getAccessToken(), false)));
    } else {
      this.initializeOdicService();
      return from(this.oauth.loadDiscoveryDocument(this.discoveryDocUrl)).pipe(mergeMap(() => this.refreshLogin()));
    }
  }

  private processLoginResponse(accessToken: string, rememberMe: boolean) {
    if (accessToken == null) {
      throw new Error('accessToken cannot be null');
    }

    const jwtHelper = new JwtHelper();
    const decodedAccessToken = jwtHelper.decodeToken(accessToken) as AccessToken;
    const user = new ApplicationUser();

    // load the profile from the service
    this.oauth.loadUserProfile().then((val: any) => {
      user.email = val.email;
      user.emailConfirmed = val.email_verified;
      user.id = val.sub;
      user.userName = val.name;

      let prf:UserProfile = {
        id:val.sub,
        emailAddress:val.email,
        username:val.name,
        profileImage:'',
        phoneNumber:''
      };
      this.store.LoginUser(prf);
      this._currentUser = prf;
      this._loginStatus.next(true);
      this._userUpdated.next(user);
      return user;
    });
    return user;
  }

  /** Sign Out  */
  public signOut() {
    if (this.isLoggedIn) {
      this._currentUser = null;
      this._userUpdated.next(null);
      this.store.clearAuthentication();
      this.oauth.logOut();
      this._loginStatus.next(false);
    }
  }

  private reevaluateLogin() {
    const user = this._currentUser;
    const isLoggedIn = user != null;
    if (this.previousIsLoggedInCheck != isLoggedIn) {
      setTimeout(() => {
        this._loginStatus.next(isLoggedIn);
      });
    }
    this.previousIsLoggedInCheck = isLoggedIn;
  }

  reLogin() {
    if (this.reLoginDelegate) {
      this.reLoginDelegate();
    } else {
      this.loginRedirectUrl = this.router.url;
      this.router.navigate(['/auth/signin']);
    }
  }
}
