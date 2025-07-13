import { Component } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { CartItem } from 'src/app/shared/models/cart';
import { CommonModule } from '@angular/common';
import { CartSummaryComponent } from 'src/app/shared/components/cart-summary/cart-summary.component';
import { OrderTotalsComponent } from 'src/app/shared/components/order-totals/order-totals.component';
import { EmptyStateComponent } from 'src/app/shared/components/empty-state/empty-state.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [    
    CommonModule,
    CartSummaryComponent,
    OrderTotalsComponent,
    EmptyStateComponent
  ],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent {
  constructor(public cartService: CartService, private router: Router) {}  

  incrementQuantity(item: CartItem) {
    this.cartService.addItemToCart(item);
  }

  removeItem(event: {id: number, quantity: number}) {
    this.cartService.removeItemFromCart(event.id, event.quantity);
  }

  onAction() {
    this.router.navigateByUrl('/shop');
  }
}
