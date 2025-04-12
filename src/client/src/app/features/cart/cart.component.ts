import { Component } from '@angular/core';
import { CartItem } from '../shared/models/cart';
import { CartService } from './cart.service';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.scss'],
    standalone: false
})
export class CartComponent {

  constructor(public cartService: CartService) {}  

  incrementQuantity(item: CartItem) {
    this.cartService.addItemToCart(item);
  }

  removeItem(event: {id: number, quantity: number}) {
    this.cartService.removeItemFromCart(event.id, event.quantity);
  }
}
