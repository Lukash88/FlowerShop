import { Pipe, PipeTransform } from '@angular/core';
import { ConfirmationToken } from '@stripe/stripe-js';

@Pipe({
  name: 'paymentCard',
  standalone: true
})
export class PaymentCardPipe implements PipeTransform {

  transform(value?: ConfirmationToken['payment_method_preview'], ...args: unknown[]): unknown {
    if (value?.card) {
      const { brand, last4, exp_month, exp_year } = value.card;
      return `${ brand.toLocaleUpperCase() } **** **** **** ${ last4 }, Expires: ${ exp_month }/${ exp_year }`;
    } else {
      return 'No payment card provided';
    }
  }
}
