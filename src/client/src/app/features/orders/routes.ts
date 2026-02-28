import { Route } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderDetailedComponent } from './order-detailed/order-detailed.component';
import { authGuard } from 'src/app/core/guards/auth.guard';

export const orderRoutes: Route[] = [
  {
    path: 'all',
    component: OrdersComponent,
    data: { breadcrumb: 'All Orders' },
    canActivate: [authGuard]
  },
  {
    path: 'userOrders',
    component: OrdersComponent,
    data: { breadcrumb: 'User Orders' },
    canActivate: [authGuard]
  },
  {
    path: 'userOrders/:id',
    component: OrderDetailedComponent,
    data: { breadcrumb: { alias: 'OrderDetailed' } },
    canActivate: [authGuard]
  },
];