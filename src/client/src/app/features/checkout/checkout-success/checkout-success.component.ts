import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { AddressPipe } from 'src/app/shared/pipes/address.pipe';
import { PaymentCardPipe } from 'src/app/shared/pipes/payment-card.pipe';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { OrderService } from 'src/app/core/services/order.service';
import { CartService } from 'src/app/core/services/cart.service';

@Component({
    selector: 'app-checkout-success',
    standalone: true,
    imports: [
      MatButton,
      RouterLink,
      MatProgressSpinnerModule,
      DatePipe,
      AddressPipe,
      CurrencyPipe,
      PaymentCardPipe
    ],
    templateUrl: './checkout-success.component.html',
    styleUrls: ['./checkout-success.component.scss']
})
export class CheckoutSuccessComponent implements OnInit, OnDestroy {
  signalrService = inject(SignalrService);
  private orderService = inject(OrderService);
  private cartService = inject(CartService);

  ngOnInit(): void {
    this.orderService.orderComplete = true;
    this.cartService.selectedDelivery.set(null);
    this.cartService.cart.set(null);
  }

  ngOnDestroy(): void {
    this.orderService.orderComplete = false;
    this.signalrService.orderSignal.set(null);
  }
}
