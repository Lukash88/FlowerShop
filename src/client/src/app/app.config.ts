import { ApplicationConfig, inject, provideAppInitializer, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { lastValueFrom } from 'rxjs';
import { InitService } from './core/services/init.service';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { loadingInterceptor } from './core/interceptors/loading.interceptor';
import { jwtInterceptor } from './core/interceptors/jwt.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([
      loadingInterceptor,
      jwtInterceptor
    ])),
    provideAppInitializer(() => {
      const initService = inject(InitService);
      return lastValueFrom(initService.init()).finally(() => {
        const splash = document.getElementById('initial-splash');
        if (splash) splash.remove();
      });
    })
  ]
};
