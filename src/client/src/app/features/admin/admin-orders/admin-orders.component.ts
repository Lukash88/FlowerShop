import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../../../core/services/admin.service';
import { Order, OrderStatusOptions } from '../../../shared/models/order';
import { OrderParams } from '../../../shared/models/orderParams';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { DialogService } from '../../../core/services/dialog.service';
import { CommonModule } from '@angular/common';
import { CustomTableComponent } from "../../../shared/components/custom-table/custom-table.component";
import { Router } from '@angular/router';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-admin-orders',
  standalone: true,
  imports: [
    MatPaginatorModule,
    MatSelectModule,
    CommonModule,
    CustomTableComponent
],
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.scss']
})
export class AdminOrdersComponent implements OnInit {
  orders: Order[] = [];
  statusOptions = OrderStatusOptions;
  private adminService = inject(AdminService);
  private dialogService = inject(DialogService);
  private router = inject(Router);
  orderParams = new OrderParams();
  totalItems = 0;

  columns = [
    { field: 'id', header: 'No.' },
    { field: 'buyerEmail', header: 'Buyer Email' },
    { field: 'createdAt', header: 'Order Date', pipe: 'date', pipeArgs: { year: 'numeric', month: 'short', day: 'numeric' } },
    { field: 'total', header: 'Total', pipe: 'currency', pipeArgs: 'USD' },
    { field: 'status', header: 'Status' }
  ];

  actions = [
    {
      label: 'View',
      icon: 'visibility',
      color: 'text-blue-700',
      tooltip: 'View Order',
      action: (row: any) => {
        this.router.navigateByUrl(`admin/orders/${row.id}`)
      }
    },
    {
      label: 'Refund',
      icon: 'undo',
      color: 'text-red-700',
      tooltip: 'Refund Order',
      disabled: (row: any) => row.status === 'Refunded',
      action: (row: any) => {
        this.openConfirmDialog(row);
      }
    }
  ];  

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.adminService.getOrders(this.orderParams).subscribe({
      next: (response: any) => {
        if (response.data) {
          this.orders = response.data.results;
          this.totalItems = response.data.rowCount;
        }
      },
    });
  }
  
 onPageChange(event: PageEvent) {
    this.orderParams.pageNumber = event.pageIndex + 1;
    this.orderParams.pageSize = event.pageSize;
    this.loadOrders();
  }

  onFilterSelect(event: MatSelectChange) {
    this.orderParams.filter = event.value;
    this.orderParams.pageNumber = 1;
    this.loadOrders();
  } 

  onAction(action: (row: any) => void, row: any) {
    action(row);
  }

  async openConfirmDialog(order: Order) {
    const confirmed = await this.dialogService.confirm(
      `Refund order #${order.id} for $${order.total}?`,
      'This action cannot be undone.',
    );
    if (confirmed) this.refundOrder(order.id);
  }

  refundOrder(id: number) {
    this.adminService.refundOrder(id).subscribe({
      next: (response: any) => {
        const order = response.data;

        this.orders = this.orders.map(o => o.id === id ? order : o);
        this.loadOrders();
      }
    });
  }
}