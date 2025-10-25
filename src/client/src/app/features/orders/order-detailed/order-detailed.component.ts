import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from 'src/app/core/services/order.service';
import { Order } from 'src/app/shared/models/order';
import { AddressPipe } from 'src/app/shared/pipes/address.pipe';
import { PaymentCardPipe } from 'src/app/shared/pipes/payment-card.pipe';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-order-detailed',
  standalone: true,
  imports: [
    DatePipe,
    CurrencyPipe,
    MatCardModule,
    MatButton,
    AddressPipe,
    PaymentCardPipe
  ],
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss'],
})
export class OrderDetailedComponent implements OnInit {
  order?: Order;

  ngOnInit(): void {
    this.loadOrder();
  }

  constructor(
    private orderService: OrderService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private router: Router
  ) {}
  loadOrder() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;

    const loadOrderData = this.orderService.getOrderDetailed(+id);

    loadOrderData.subscribe({
      next: (order: any) => (this.order = order.data),
    });
  }

  onReturnClick() { :
    this.router.navigateByUrl('/orders/userOrders');
  }
}
