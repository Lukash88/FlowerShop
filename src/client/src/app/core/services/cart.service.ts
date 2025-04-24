import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Cart, CartItem, CartTotals } from 'src/app/shared/models/cart';
import { Product } from 'src/app/shared/models/product';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;
  private cartSource = new BehaviorSubject<Cart | null>(null);
  cartSource$ = this.cartSource.asObservable();
  private cartTotalSource = new BehaviorSubject<CartTotals | null>(null);
  cartTotalSource$ = this.cartTotalSource.asObservable();
  shippingPrice = 0.00;

  constructor(private http: HttpClient) { }

  createPaymentIntent() {
    return this.http.post<Cart>(this.baseUrl + 'payments/' + this.getCurrentCartValue()?.id, { })
    .pipe(
      map((cart: any) => {
        cart = cart.data;
        console.log(cart);
        this.cartSource.next(cart);
      })
    );
  }

  getCart(id: string) {
    return this.http.get<Cart>(this.baseUrl + 'cart/' + id).subscribe({
      next: (cart: any) => {
        cart = cart.data;
        this.cartSource.next(cart);
        this.calculateTotals();
      },
    });
  }

  setCart(cart: Cart) {
    return this.http.post<Cart>(this.baseUrl + 'cart/' + cart.id, cart).subscribe({
      next: (cart: any) => {
        cart = cart.data;
        this.cartSource.next(cart);
        this.calculateTotals();
      },
    });
  }

  getCurrentCartValue() {
    return this.cartSource.value;
  }

  addItemToCart(item: Product | CartItem, quantity = 1) {
    if (this.isProduct(item)) item = this.mapProductItemToCartItem(item);
    const cart = this.getCurrentCartValue() ?? this.createCart();
    cart.items = this.addOrUpdateItem(cart.items, item, quantity);
    this.setCart(cart);
  }

  removeItemFromCart(id: number, quantity = 1) {
    const cart = this.getCurrentCartValue();
    if (!cart) return;
    const item = cart.items.find((x) => x.productId === id);
    if (item) {
      item.quantity -= quantity;
      if (item.quantity === 0) {
        cart.items = cart.items.filter((x) => x.productId !== id);
      }
      if (cart.items.length > 0) this.setCart(cart);
      else this.deleteCart(cart);
    }
  }

  deleteCart(cart: Cart) {    
    return this.http.delete(this.baseUrl + 'cart/' + cart.id).subscribe({
      next: () => {
        this.deleteLocalCart();
        this.shippingPrice = 0.00;
      }
    });
  }

  deleteLocalCart() {
    this.cartSource.next(null);
    this.cartTotalSource.next(null);
    localStorage.removeItem('cart_id');
  }

  private calculateTotals() {
    const cart = this.getCurrentCartValue();
    if (!cart) return;
    const subtotal = cart.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const tax = subtotal * 0.08;
    const total = subtotal + this.shippingPrice;
    this.cartTotalSource.next({ shipping: this.shippingPrice, subtotal, tax, total });
  }

  private addOrUpdateItem(items: CartItem[], itemToAdd: CartItem, quantity: number): CartItem[] {
    const item = items.find(x => x.productId === itemToAdd.productId);
    if (item) item.quantity += quantity;
    else {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }
    return items;
  }

  private createCart(): Cart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }

  private mapProductItemToCartItem(item: Product): CartItem {
    return {
      productId: item.id,
      productName: item.name,
      shortDescription: item.shortDescription,
      price: item.price,
      quantity: 0,
      imageUrl: item.imageUrl,
      category: item.category
    };
  }

  private isProduct(item: Product | CartItem): item is Product {
    return (item as Product).longDescription !== undefined;
  }

  setShippingPrice(deliveryMethod: DeliveryMethod) {
    const cart = this.getCurrentCartValue(); 
    if (deliveryMethod && cart) {
      cart.deliveryMethodId = deliveryMethod.id;
      this.shippingPrice = deliveryMethod.price;
      this.setCart(cart);
    }    
  }
}