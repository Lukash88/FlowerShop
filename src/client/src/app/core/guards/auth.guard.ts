import { inject } from '@angular/core';
import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { toObservable } from '@angular/core/rxjs-interop';
import { map } from 'rxjs';
import { AccountService } from '../services/account.service';

export const authGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  return toObservable(accountService.currentUser).pipe(
    map(user => {
      if (user) return true;
      router.navigate(['/account/login'], { queryParams: { returnUrl: state.url } });
      return false;
    })
  );
};
