import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snackbar = inject(SnackbarService);

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {

      switch (err.status) {

        case 400:
          if (err.error?.errors) {
            const modelStateErrors: string[] = [];

            for (const key in err.error.errors) {
              if (err.error.errors[key]) {
                modelStateErrors.push(...err.error.errors[key]);
              }
            }

            return throwError(() => modelStateErrors);
          } else {
            snackbar.error(err.error?.title || 'Bad request');
          }
          break;

        case 401:
          snackbar.error(err.error?.title || 'Unauthorized');
          break;

        case 403:
          snackbar.error('Forbidden');
          break;

        case 404:
          break;

        case 500:
          if (!router.url.includes('server-error')) {
            router.navigate(['/server-error'], {
              state: {
                failedUrl: router.url,
                message: err.error?.message
              },
              replaceUrl: true
            });
          }
          break;

        default:
          snackbar.error('Unexpected error occurred.');
          break;
      }

      return throwError(() => err);
    })
  );
};
