import { Component, inject, OnDestroy } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { AddressPipe } from 'src/app/shared/pipes/address.pipe';
import { PaymentCardPipe } from 'src/app/shared/pipes/payment-card.pipe';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { OrderService } from 'src/app/core/services/order.service';

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
export class CheckoutSuccessComponent implements OnDestroy {
  signalrService = inject(SignalrService);
  private orderService = inject(OrderService);

  ngOnDestroy(): void {
    this.orderService.orderComplete = false;
    this.signalrService.orderSignal.set(null);
  }
}
