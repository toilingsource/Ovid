
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private auth: AuthService,
    private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // the user is logged in
    if (this.auth.isLoggedIn && !this.auth.isSessionExpired)
      return true;
    else if (this.auth.isLoggedIn && this.auth.isSessionExpired) {
      this.auth.refreshLogin().subscribe((v) => {
        return true;
      },err=>{
        this.router.navigateByUrl(`/auth/signin?return=${next.url}`);
        return false;  
      });
    } else {
      this.router.navigateByUrl(`/auth/signin?return=${next.url}`);
      return false;
    }
  }

}
