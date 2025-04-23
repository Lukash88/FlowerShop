import { Component, Output, EventEmitter, Input } from '@angular/core';
import { CartItem } from '../../models/cart';
import { CartService } from 'src/app/core/services/cart.service';

@Component({
    selector: 'app-basket-summary',
    standalone: true,
    templateUrl: './cart-summary.component.html',
    styleUrls: ['./cart-summary.component.scss']    
})
export class CartSummaryComponent {
  @Output() addItem = new EventEmitter<CartItem>();
  @Output() removeItem = new EventEmitter<{ id: number, quantity: number }>();
  @Input() isBasket = true;

  constructor(public cartService: CartService) {}

  addBasketItem(item: CartItem) {
    this.addItem.emit(item);
  }

  removeBasketItem(id: number, quantity = 1) {
    this.removeItem.emit({ id, quantity });
  }
}