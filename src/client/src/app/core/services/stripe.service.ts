import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { loadStripe, Stripe, StripeAddressElement, StripeAddressElementOptions, StripeCardCvcElement, StripeCardExpiryElement, StripeCardNumberElement, StripeElements } from '@stripe/stripe-js';
import { BehaviorSubject, firstValueFrom, map } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { Basket } from 'src/app/shared/models/basket';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StripeService {
  baseUrl = environment.apiUrl;
  private stripePromise?: Promise<Stripe | null>;  
  private basketSource = new BehaviorSubject<Basket | null>(null);

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

  constructor(private basketService: BasketService, private accountService: AccountService,
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
        const basket = await firstValueFrom(this.createOrUpdatePaymentIntent());
        this.elements = stripe.elements(
          { clientSecret: basket.clientSecret, appearance: { labels: 'floating' }});
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
    const basket = this.basketService.getCurrentBasketValue();
    if (!basket) throw new Error('Problem with basket');
    return this.http.post<Basket>(this.baseUrl + 'payments/' + basket.id, { })
    .pipe(
      map((basket: any) => {        
        basket = basket.data;
        this.basketService.setBasket(basket);
        console.log(basket);
        this.basketSource.next(basket);
        return basket;
      })
    );
  }
}
