import { Component, Output, EventEmitter, Input } from '@angular/core';
import { CartItem } from '../../models/cart';
import { CartService } from 'src/app/core/services/cart.service';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-cart-summary',
    standalone: true,
    imports: [
      CommonModule,
      CurrencyPipe,
      RouterModule
    ],
    templateUrl: './cart-summary.component.html',
    styleUrls: ['./cart-summary.component.scss']    
})
export class CartSummaryComponent {
  @Output() addItem = new EventEmitter<CartItem>();
  @Output() removeItem = new EventEmitter<{ id: number, quantity: number }>();
  @Input() isCart = true;

  constructor(public cartService: CartService) {}

  addCartItem(item: CartItem) {
    this.addItem.emit(item);
  }

  removeCartItem(id: number, quantity = 1) {
    this.removeItem.emit({ id, quantity });
  }
}