import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrderService } from 'src/app/core/services/order.service';
import { Order, PaginationParams } from 'src/app/shared/models/order';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [
    RouterModule,
    DatePipe,
    CurrencyPipe
  ],
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  paginationParams = new PaginationParams();
  totalCount = 0;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrdersForUser(this.paginationParams).subscribe({
      next: (response: any) => {
        this.orders = response.data.results;
        this.paginationParams.pageNumber = response.data.currentPage;
        this.paginationParams.pageSize = response.data.pageSize;
        this.totalCount = response.data.rowCount;
      },
      error: (error: any) => console.log(error.error),
    });
  }

  onPageChanged(event: any) {
    if (this.paginationParams.pageNumber !== event) {
      this.paginationParams.pageNumber = event;
      this.getOrders();
    }
  }
}
