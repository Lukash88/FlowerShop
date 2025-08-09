import { CurrencyPipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ConfirmationToken } from '@stripe/stripe-js';
import { AddressPipe } from "../../../shared/pipes/address.pipe";
import { PaymentCardPipe } from "../../../shared/pipes/payment-card.pipe";

@Component({
    selector: 'app-checkout-review',
    standalone: true,
    imports: [
    CurrencyPipe,
    MatProgressSpinnerModule,
    AddressPipe,
    PaymentCardPipe
],
    templateUrl: './checkout-review.component.html',
    styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent {
  @Input() confirmationToken?: ConfirmationToken;

  constructor(public cartService: CartService) { }
}
