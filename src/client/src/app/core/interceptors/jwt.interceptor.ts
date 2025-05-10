import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, switchMap, take } from 'rxjs';
import { AccountService } from '../services/account.service';
import { toObservable } from '@angular/core/rxjs-interop';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  token?: string;
  constructor(private accountService: AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return toObservable(this.accountService.currentUser).pipe(
      take(1),
      switchMap(user => {
        if (user?.token) {
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${user.token}`
            }
          });
        }
        return next.handle(request);
      })
    );
  }
}