import { Component, inject } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { CartItemComponent } from './cart-item/cart-item.component';
import { OrderTotalsComponent } from 'src/app/shared/components/order-totals/order-totals.component';
import { Router } from '@angular/router';
import { EmptyStateComponent } from 'src/app/shared/components/empty-state/empty-state.component';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    CartItemComponent,
    OrderTotalsComponent,
    EmptyStateComponent
  ],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent {
  private router = inject(Router);
  cartService = inject(CartService);

  onAction() {
    this.router.navigateByUrl('/shop');
  }
}
