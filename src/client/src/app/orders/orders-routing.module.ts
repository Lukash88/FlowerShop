import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderDetailedComponent } from '../order-detailed/order-detailed.component';

const routes: Routes = [
  { path: 'all', component: OrdersComponent, data: { breadcrumb: 'All Orders' }},
  { path: '/:id', component: OrderDetailedComponent, data: { breadcrumb: 'All Orders' }},
  { path: 'userOrders', component: OrdersComponent, data: { breadcrumb: 'User Orders' }},
  { path: 'userOrders/:id', component: OrderDetailedComponent, data: { breadcrumb: { alias: 'OrderDetailed' }}}
  ]  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
