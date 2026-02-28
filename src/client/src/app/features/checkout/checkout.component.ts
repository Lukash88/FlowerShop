import { Component, inject, OnDestroy, OnInit, signal } from '@angular/core';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';
import { MatButton } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { StripeService } from '../../core/services/stripe.service';
import {
  ConfirmationToken,
  StripeAddressElement,
  StripeAddressElementChangeEvent,
  StripePaymentElement,
  StripePaymentElementChangeEvent
} from '@stripe/stripe-js';
import {
  MatCheckboxChange,
  MatCheckboxModule
} from '@angular/material/checkbox';
import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { Address } from '../../shared/models/user';
import { firstValueFrom } from 'rxjs';
import { AccountService } from '../../core/services/account.service';
import { CheckoutDeliveryComponent } from './checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';
import { CartService } from '../../core/services/cart.service';
import { CurrencyPipe } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { OrderToCreate, ShippingAddress } from '../../shared/models/order';
import { OrderTotalsComponent } from 'src/app/shared/components/order-totals/order-totals.component';
import { OrderService } from 'src/app/core/services/order.service';
import { SignalrService } from 'src/app/core/services/signalr.service';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [
    OrderTotalsComponent,
    MatStepperModule,
    MatButton,
    RouterLink,
    MatCheckboxModule,
    CheckoutDeliveryComponent,
    CheckoutReviewComponent,
    CurrencyPipe,
    MatProgressSpinnerModule,
  ],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent implements OnInit, OnDestroy {
  private signalrService = inject(SignalrService);
  addressElement?: StripeAddressElement;
  paymentElement?: StripePaymentElement;
  saveAddress = false;
  completionStatus = signal<{
    address: boolean;
    card: boolean;
    delivery: boolean;
  }>({ address: false, card: false, delivery: false });
  confirmationToken?: ConfirmationToken;
  loading = false;

  constructor(
    private accountService: AccountService,
    public cartService: CartService,
    private stripeService: StripeService,
    private orderService: OrderService,
    private router: Router
  ) {}

  async ngOnInit() {
    try {
      this.addressElement = await this.stripeService.createAddressElement();
      this.addressElement.mount('#address-element');
      this.addressElement.on('change', this.handleAddressChange);

      this.paymentElement = await this.stripeService.createPaymentElement();
      this.paymentElement.mount('#payment-element');
      this.paymentElement.on('change', this.handlePaymentChange);
    } catch (error: any) {
      console.log(error.message);
    }
  }

  handleAddressChange = (event: StripeAddressElementChangeEvent) => {
    setTimeout(() => {
      this.completionStatus.update((state) => ({
        ...state,
        address: event.complete,
      }));
    });
  };

  handlePaymentChange = (event: StripePaymentElementChangeEvent) => {
    setTimeout(() => {
      this.completionStatus.update((state) => ({
        ...state,
        card: event.complete,
      }));
    });
  };

  handleDeliveryChange(event: boolean) {
    this.completionStatus.update((state) => ({
      ...state,
      delivery: event,
    }));
  }

  async getConfirmationToken() {
    try {
      if (
        Object.values(this.completionStatus()).every(
          (status) => status === true
        )
      ) {
        const result = await this.stripeService.createConfirmationToken();
        if (result.error) throw new Error(result.error.message);
        this.confirmationToken = result.confirmationToken;
      }
    } catch (error: any) {
      console.log(error.message);
    }
  }

  async onStepChange(event: StepperSelectionEvent) {
    if (event.selectedIndex === 1) {
      if (this.saveAddress) {
        const address = (await this.getAddressFromStripeAddress()) as Address;
        address && firstValueFrom(this.accountService.updateUserAddress(address));
      }
    }
    if (event.selectedIndex === 2) {
      await firstValueFrom(this.stripeService.createOrUpdatePaymentIntent());
    }
    if (event.selectedIndex === 3) {
      await this.getConfirmationToken();
    }
  }

  async confirmPayment(stepper: MatStepper) {
    this.loading = true;
    try {
      if (this.confirmationToken) {
        const order = await this.createOrderModel();
        const orderResult = await firstValueFrom(
          this.orderService.createOrder(order),
        );
        if (!orderResult) {
          throw new Error('Order creation failed');
        }
        const result = await this.stripeService.confirmPayment(
          this.confirmationToken,
        );
        if (result.paymentIntent?.status === 'succeeded') {
          this.orderService.orderComplete = true;
          this.signalrService.orderSignal.set(orderResult);
          this.cartService.selectedDelivery.set(null);
          this.stripeService.disposeElements();
          this.cartService.deleteCart();

          await this.router.navigateByUrl('/checkout/success');
        } else if (result.error) {
          throw new Error(result.error.message);
        }
      }
    } catch (error: any) {
      console.log(error.message || 'Something went wrong');
      stepper.previous();
    } finally {
      this.loading = false;
    }
  }

  private async createOrderModel(): Promise<OrderToCreate> {
    const cart = this.cartService.cart();
    const shippingAddress =
      (await this.getAddressFromStripeAddress()) as ShippingAddress;
    const card = this.confirmationToken?.payment_method_preview?.card;

    if (!cart?.id || !cart?.deliveryMethodId || !shippingAddress || !card) {
      throw new Error('Problem creating order');
    }

    return {
      cartId: cart.id,
      deliveryMethodId: cart.deliveryMethodId,
      shippingAddress,
      paymentSummary: {
        last4: +card.last4,
        brand: card.brand,
        expMonth: card.exp_month,
        expYear: card.exp_year,
      },
      discount: this.cartService.totals()?.discount,
    };
  }

  private async getAddressFromStripeAddress(): Promise<
    Address | ShippingAddress | null
  > {
    const result = await this.addressElement?.getValue();
    const address = result?.value.address;

    if (address) {
      return {
        name: result.value.name,
        line1: address.line1,
        line2: address.line2 || undefined,
        city: address.city,
        country: address.country,
        state: address.state,
        postalCode: address.postal_code,
      };
    } else return null;
  }

  onSaveAddressCheckboxChange(event: MatCheckboxChange) {
    this.saveAddress = event.checked;
  }

  ngOnDestroy(): void {
    this.stripeService.disposeElements();
  }
}
