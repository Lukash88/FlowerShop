import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Basket,  BasketItem, BasketTotals } from '../shared/models/basket';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from '../shared/models/product';
import { DeliveryMethod } from '../shared/models/deliveryMethod';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<BasketTotals | null>(null);
  basketTotalSource$ = this.basketTotalSource.asObservable();
  shippingPrice = 0.00;

  constructor(private http: HttpClient) { }

  createPaymentIntent() {
    return this.http.post<Basket>(this.baseUrl + 'payments/' + this.getCurrentBasketValue()?.id, { })
    .pipe(
      map((basket: any) => {
        basket = basket.data;
        console.log(basket);
        this.basketSource.next(basket);
      })
    );
  }

  getBasket(id: string) {
    return this.http.get<Basket>(this.baseUrl + 'basket/' + id).subscribe({
      next: (basket: any) => {
        basket = basket.data;
        this.basketSource.next(basket);
        this.calculateTotals();
      },
    });
  }

  setBasket(basket: Basket) {
    return this.http.post<Basket>(this.baseUrl + 'basket/' + basket.id, basket).subscribe({
      next: (basket: any) => {
        basket = basket.data;
        this.basketSource.next(basket);
        this.calculateTotals();
      },
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: Product | BasketItem, quantity = 1) {
    if (this.isProduct(item)) item = this.mapProductItemToBasketItem(item);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, item, quantity);
    this.setBasket(basket);
  }

  removeItemFromBasket(id: number, quantity = 1) {
    const basket = this.getCurrentBasketValue();
    if (!basket) return;
    const item = basket.items.find((x) => x.id === id);
    if (item) {
      item.quantity -= quantity;
      if (item.quantity === 0) {
        basket.items = basket.items.filter((x) => x.id !== id);
      }
      if (basket.items.length > 0) this.setBasket(basket);
      else this.deleteBasket(basket);
    }
  }

  deleteBasket(basket: Basket) {    
    return this.http.delete(this.baseUrl + 'basket/' + basket.id).subscribe({
      next: () => {
        this.deleteLocalBasket();
        this.shippingPrice = 0.00;
      }
    });
  }

  deleteLocalBasket() {
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    if (!basket) return;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const tax = subtotal * 0.08;
    const total = subtotal + this.shippingPrice;
    this.basketTotalSource.next({ shipping: this.shippingPrice, subtotal, tax, total });
  }

  private addOrUpdateItem(items: BasketItem[], itemToAdd: BasketItem, quantity: number): BasketItem[] {
    const item = items.find(x => x.id === itemToAdd.id);
    if (item) item.quantity += quantity;
    else {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }
    return items;
  }

  private createBasket(): Basket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(item: Product): BasketItem {
    return {
      id: item.id,
      name: item.name,
      shortDescription: item.shortDescription,
      price: item.price,
      quantity: 0,
      imageUrl: item.imageUrl,
      category: item.category
    };
  }

  private isProduct(item: Product | BasketItem): item is Product {
    return (item as Product).longDescription !== undefined;
  }

  setShippingPrice(deliveryMethod: DeliveryMethod) {
    const basket = this.getCurrentBasketValue(); 
    if (deliveryMethod && basket) {
      basket.deliveryMethodId = deliveryMethod.id;
      this.shippingPrice = deliveryMethod.price;
      this.setBasket(basket);
    }    
  }
}