import { Route } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderDetailedComponent } from './order-detailed/order-detailed.component';
import { authGuard } from 'src/app/core/guards/auth.guard';

export const orderRoutes: Route[] = [
  {
    path: '',
    component: OrdersComponent,
    data: { breadcrumb: 'My Orders' },
    canActivate: [authGuard]
  },
  {
    path: ':id',
    component: OrderDetailedComponent,
    data: { breadcrumb: { alias: 'OrderDetailed' } },
    canActivate: [authGuard]
  },
];