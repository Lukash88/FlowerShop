import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from 'src/environments/environment';
import { firstValueFrom } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Cart, CartItem } from 'src/app/shared/models/cart';
import { Product } from 'src/app/shared/models/product';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;  
  private http = inject(HttpClient);
  cart = signal<Cart | null>(null);
  itemCount = computed(() => {
    return this.cart()?.items.reduce((sum, item) => sum + item.quantity, 0)
  });
  selectedDelivery = signal<DeliveryMethod | null>(null);
  totals = computed(() => {
    const cart = this.cart();
    const delivery = this.selectedDelivery();

    if (!cart) return null;
    const subtotal = cart.items.reduce((sum, item) => sum + item.price * item.quantity, 0);      
    const tax = subtotal * 0.08;
    const shipping = delivery ? delivery.price : 0;

    return {
      subtotal,
      shipping,
      tax,
      total: subtotal + shipping
    }
  });

  createPaymentIntent() {
    return this.http.post<Cart>(this.baseUrl + 'payments/' + this.cart()?.id, { })
    .pipe(
      map((cart: any) => {
        cart = cart.data;
        console.log(cart);
        return cart;
      })
    );
  }

  getCart(id: string) {
    return this.http.get<Cart>(this.baseUrl + 'cart/' + id).pipe(
      map((cart: any) => {
        cart = cart.data;
        this.cart.set(cart);
        return cart;
      })
    )
  }

  setCart(cart: Cart) {
    return this.http.post<Cart>(this.baseUrl + 'cart/' + cart.id, cart).pipe(
      tap((cart: any)=> {
        cart = cart.data;
        this.cart.set(cart)
      })
    )
  }

  async addItemToCart(item: CartItem | Product, quantity = 1) {
    const cart = this.cart() ?? this.createCart();
    if (this.isProduct(item)) {
      item = this.mapProductToCartItem(item);
    }
    cart.items = this.addOrUpdateItem(cart.items, item, quantity);
    await firstValueFrom(this.setCart(cart));
  }

  async removeItemFromCart(productId: number, quantity = 1) {
    const cart = this.cart();
    if (!cart) return;
    const index = cart.items.findIndex(x => x.productId === productId);
    if (index !== -1) {
      if (cart.items[index].quantity > quantity) {
        cart.items[index].quantity -= quantity;
      } else {
        cart.items.splice(index, 1);
      }
      if (cart.items.length === 0) {
        this.deleteCart();
      } else {
        await firstValueFrom(this.setCart(cart));
      }
    }
  }

  deleteCart() {    
    return this.http.delete(this.baseUrl + 'cart/' + this.cart()?.id).subscribe({
      next: () => {
        localStorage.removeItem('cart_id');
        this.cart.set(null);
      }
    });
  }

  private addOrUpdateItem(items: CartItem[], item: CartItem, quantity: number): CartItem[] {
    const index = items.findIndex(x => x.productId === item.productId);
    if (index === -1) {
      item.quantity = quantity;
      items.push(item);
    } else {
      items[index].quantity += quantity
    }
    return items;
  }

  private createCart(): Cart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }

  private mapProductToCartItem(item: Product): CartItem {
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
}