import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../services/account.service';

import { toObservable } from '@angular/core/rxjs-interop';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard  {

  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return toObservable(this.accountService.currentUser).pipe(
      map(user => {
        if (user) return true;
        this.router.navigate(['/account/login'], { queryParams: { returnUrl: state.url } });
        return false;
      })
    );
  } 
}