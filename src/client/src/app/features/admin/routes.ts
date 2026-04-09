import { Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { OrderDetailedComponent } from '../orders/order-detailed/order-detailed.component';
import { OrdersComponent } from '../orders/orders.component';
import { authGuard } from 'src/app/core/guards/auth.guard';

export const adminRoutes: Routes = [
  { path: '',
    component: AdminComponent
  },
  {
    path: 'orders',
    component: OrdersComponent,
    data: { breadcrumb: 'Orders' },
    canActivate: [authGuard]
  },
  { path: 'orders/:id',
    component: OrderDetailedComponent,
    data: { breadcrumb: 'Order Details' },
    canActivate: [authGuard]}
];