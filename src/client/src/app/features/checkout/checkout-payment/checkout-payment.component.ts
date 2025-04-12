import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CartService } from 'src/app/cart/cart.service';
import { CheckoutService } from '../checkout.service';
import { Cart } from 'src/app/shared/models/cart';
import { Address } from 'src/app/shared/models/user';
import { NavigationExtras, Router } from '@angular/router';
import { Stripe, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement, loadStripe } from '@stripe/stripe-js';
import { firstValueFrom } from 'rxjs';
import { OrderToCreate } from 'src/app/shared/models/order';

@Component({
    selector: 'app-checkout-payment',
    templateUrl: './checkout-payment.component.html',
    styleUrls: ['./checkout-payment.component.scss'],
    standalone: false
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm?: FormGroup;
  @ViewChild('cardNumber') cardNumberElement?: ElementRef;
  @ViewChild('cardExpiry') cardExpiryElement?: ElementRef;
  @ViewChild('cardCvc') cardCvcElement?: ElementRef;
  stripe: Stripe | null = null;
  cardNumber?: StripeCardNumberElement;
  cardExpiry?: StripeCardExpiryElement;
  cardCvc?: StripeCardCvcElement;
  cardNumberComplete = false;
  cardExpiryComplete = false;
  cardCvcComplete = false;
  cardErrors: any;
  loading = false;

  constructor(private cartService: CartService, private checkoutService: CheckoutService,
    private router: Router) {}

  ngOnInit(): void {
    loadStripe('Your publishable test key from Stripe')
      .then(stripe => {
        this.stripe = stripe;
        const elements = stripe?.elements();
        if (elements){
          this.cardNumber = elements.create('cardNumber');
          this.cardNumber.mount(this.cardNumberElement?.nativeElement);
          this.cardNumber.on('change', event => {
            this.cardNumberComplete = event.complete;
            if (event.error) this.cardErrors = event.error.message;
            else this.cardErrors = null;
          });

          this.cardExpiry = elements.create('cardExpiry');
          this.cardExpiry.mount(this.cardExpiryElement?.nativeElement);
          this.cardExpiry.on('change', event => {
            this.cardExpiryComplete = event.complete;
            if (event.error) this.cardErrors = event.error.message;
            else this.cardErrors = null;
          });

          this.cardCvc = elements.create('cardCvc');
          this.cardCvc.mount(this.cardCvcElement?.nativeElement);
          this.cardCvc.on('change', event => {
            this.cardCvcComplete = event.complete;
            if (event.error) this.cardErrors = event.error.message;
            else this.cardErrors = null;
          });
        }
      });
  }

  get paymentFormComplete() {
    return this.checkoutForm?.get('paymentForm')?.valid && this.cardNumberComplete 
      && this.cardExpiryComplete && this.cardCvcComplete;
  }

  async submitOrder() {
    this.loading = true;
    const cart = this.cartService.getCurrentCartValue();
    if (!cart) throw new Error('Cannot get cart');
    try {
      const createdOrder = await this.createOrder(cart);
      const paymentResult = await this.confirmPaymentWithStripe(cart);
      if (paymentResult.paymentIntent) {
        this.cartService.deleteCart(cart);        
        const navigationExtras: NavigationExtras = { state: createdOrder };
        this.router.navigate(['checkout/success'], navigationExtras);
      } else {
        console.log(paymentResult.error.message);
      }  
    } catch (error: any) {
      console.log(error);
    } finally {
      this.loading = false;
    }
  }

  private async confirmPaymentWithStripe(cart: Cart | null) {
    if (!cart) throw new Error('Cart is null');
    const result = this.stripe?.confirmCardPayment(cart.clientSecret!, {
      payment_method: {
        card: this.cardNumber!,
        billing_details: {
          name: this.checkoutForm?.get('paymentForm')?.get('nameOnCard')?.value
        }
      }
    });
    if (!result) throw new Error('Problem attempting payment with Stripe')
    return result;
  }  
  
  private async createOrder(cart: Cart | null) {
    if (!cart) throw new Error('Cart is null');
    const orderToCreate = this.getOrderToCreate(cart);    
    return firstValueFrom(this.checkoutService.createOrder(orderToCreate));
  }

  private getOrderToCreate(cart: Cart): OrderToCreate {
    const deliveryMethodId = this.checkoutForm?.get('deliveryForm')?.get('deliveryMethod')?.value;
    const shipToAddress = this.checkoutForm?.get('addressForm')?.value as Address;    
    if (!deliveryMethodId || !shipToAddress) throw new Error('Problem with cart');
    return {
      cartId: cart.id,
      deliveryMethodId: deliveryMethodId,
      shipToAddress: shipToAddress
    }
  }
}
