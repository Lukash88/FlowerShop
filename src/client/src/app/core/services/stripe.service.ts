import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { loadStripe, Stripe, StripeAddressElement, StripeAddressElementOptions, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement, StripeElements } from '@stripe/stripe-js';
import { firstValueFrom, map } from 'rxjs';
import { Cart } from 'src/app/shared/models/cart';
import { environment } from 'src/environments/environment';
import { AccountService } from './account.service';
import { CartService } from './cart.service';

@Injectable({
  providedIn: 'root'
})
export class StripeService {
  baseUrl = environment.apiUrl;
  private stripePromise?: Promise<Stripe | null>;
  private elements?: StripeElements;
  private addressElement?: StripeAddressElement;

  cardNumber?: StripeCardNumberElement;
  cardExpiry?: StripeCardExpiryElement;
  cardCvc?: StripeCardCvcElement;
  cardNumberComplete = false;
  cardExpiryComplete = false;
  cardCvcComplete = false;
  cardErrors: any;
  loading = false;

  constructor(private cartService: CartService, private accountService: AccountService,
    private http: HttpClient, private router: Router) {
    this.stripePromise = loadStripe(environment.stripePublicKey);
  }

  getStripeInstance() {
    return this.stripePromise;
  }

  async initializeElements() {
    if (!this.elements) {
      const stripe = await this.getStripeInstance();
      if (stripe) {
        const cart = await firstValueFrom(this.createOrUpdatePaymentIntent());
        this.elements = stripe.elements(
          { clientSecret: cart.clientSecret, appearance: { labels: 'floating' }});
      } else {
        throw new Error('Stripe has not been loaded');
      }
    }
    return this.elements;
  }

  async createAddressElement() {
    if (!this.addressElement) {
      const elements = await this.initializeElements();
      if (elements) {
        const options: StripeAddressElementOptions = {
          mode: 'shipping'
        };
        this.addressElement = elements.create('address', options);
      } else {
        throw new Error('Elements instance has not been loaded')
      }
    }
    return this.addressElement;
  }

  createOrUpdatePaymentIntent() {
    const cart = this.cartService.cart();
    if (!cart) throw new Error('Problem with cart');
    return this.http.post<Cart>(this.baseUrl + 'payments/' + cart.id, { })
    .pipe(
      map((cart: any) => {        
        cart = cart.data;
        this.cartService.setCart(cart);
        console.log(cart);
        return cart;
      })
    );
  }
}
