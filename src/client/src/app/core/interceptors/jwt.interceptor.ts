import { inject } from '@angular/core';
import { HttpInterceptorFn, HttpRequest, HttpHandlerFn, HttpEvent } from '@angular/common/http';
import { Observable, switchMap, take } from 'rxjs';
import { AccountService } from '../services/account.service';
import { toObservable } from '@angular/core/rxjs-interop';

export const jwtInterceptor: HttpInterceptorFn = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
): Observable<HttpEvent<unknown>> => {
  const accountService = inject(AccountService);

  return toObservable(accountService.currentUser).pipe(
    take(1),
    switchMap((user) => {
      let token = user?.token ?? localStorage.getItem('token');
      if (token) {
        req = req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`,
          },
        });
      }

      return next(req);
    })
  );
};
