import { Route } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderDetailedComponent } from './order-detailed/order-detailed.component';

export const orderRoutes: Route[] = [
  {
    path: 'all',
    component: OrdersComponent,
    data: { breadcrumb: 'All Orders' },
  },
  {
    path: '/:id',
    component: OrderDetailedComponent,
    data: { breadcrumb: 'All Orders' },
  },
  {
    path: 'userOrders',
    component: OrdersComponent,
    data: { breadcrumb: 'User Orders' },
  },
  {
    path: 'userOrders/:id',
    component: OrderDetailedComponent,
    data: { breadcrumb: { alias: 'OrderDetailed' } },
  },
];