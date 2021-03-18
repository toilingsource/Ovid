import { Injectable } from '@angular/core';
import { ApplicationUser } from '../models/application-user.model';
import { UserProfile } from '../models/user-profile.model';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  /** Get the current user profile stored */
  public get CurrentUser(): UserProfile {
    let usr: UserProfile = null;
    // check session storage
    let key = sessionStorage.getItem('ovid.userprofile');
    if (key == null) { // nothing in session store
      // check local storage
      key = localStorage.getItem('ovid.userprofile');
      if (key != null)
        usr = JSON.parse(key);
    } else {
      usr = JSON.parse(key);
    }
    return usr;
  }


  public clearAuthentication() {
    sessionStorage.removeItem('ovid.userprofile');
    localStorage.removeItem('ovid.userprofile');
  }


  public LoginUser(usr: UserProfile) {
    localStorage.setItem('ovid.userprofile', JSON.stringify(usr));
  }

}
