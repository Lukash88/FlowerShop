import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { CartComponent } from './features/cart/cart.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { authGuard } from './core/guards/auth.guard';
import { adminGuard } from './core/guards/admin.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'shop',
    loadChildren: () =>
      import('./features/shop/routes').then((r) => r.shopRoutes)
  },
  {
    path: 'cart/:id',
    component: CartComponent,
    data: { breadcrumb: 'Your cart' }
  },
  {
    path: 'checkout',
    loadChildren: () =>
      import('./features/checkout/routes').then((r) => r.checkoutRoutes)
  },
  {
    path: 'orders',
    loadChildren: () =>
      import('./features/orders/routes').then((r) => r.orderRoutes)
  },
  {
    path: 'account',
    loadChildren: () =>
      import('./features/account/routes').then((r) => r.accountRoutes)
  },
  {
    path: 'not-found',
    component: NotFoundComponent
  },
  {
    path: 'server-error',
    component: ServerErrorComponent
  },
  {
    path: 'admin',
    canActivate: [authGuard, adminGuard],
    loadChildren: () =>
      import('./features/admin/routes').then((r) => r.adminRoutes)
  },
  {
    path: '**',
    component: NotFoundComponent
  },
];
