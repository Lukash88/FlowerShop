import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/core/services/order.service';
import { Order, PaginationParams } from 'src/app/shared/models/order';

@Component({
    selector: 'app-orders',
    standalone: true,
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  paginationParams = new PaginationParams;
  totalCount = 0;

  constructor(private orderService: OrdersService) { }

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
      error: error => console.log(error)
    })
  }

  onPageChanged(event: any) {
    if (this.paginationParams.pageNumber !== event) {
      this.paginationParams.pageNumber = event;
      this.getOrders();
    }
  }
}