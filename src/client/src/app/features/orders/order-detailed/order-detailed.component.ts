import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/core/services/account.service';
import { AdminService } from 'src/app/core/services/admin.service';
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
  buttonText = this.accountService.isAdmin() ? 'Return to Admin' : 'Return to My Orders';

  ngOnInit(): void {
    this.loadOrder();
  }

  constructor(
    private orderService: OrderService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private router: Router,
    private accountService: AccountService,
    private adminService: AdminService
  ) {}

  loadOrder() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;

    const loadOrderData = this.accountService.isAdmin()
      ? this.adminService.getOrder(+id)
      : this.orderService.getOrderDetailed(+id);

    loadOrderData.subscribe({
      next: (order: any) => (this.order = order.data),
    });
  }

  onReturnClick() {
    this.accountService.isAdmin()
      ? this.router.navigateByUrl('/admin')
      : this.router.navigateByUrl('/orders');
  }
}
