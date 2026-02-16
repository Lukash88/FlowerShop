import { Component, inject } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { CurrencyPipe, Location } from '@angular/common';
import { MatButton, MatIconButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { StripeService } from 'src/app/core/services/stripe.service';
import { firstValueFrom } from 'rxjs';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

@Component({
  selector: 'app-order-totals',
  standalone: true,
  imports: [
    MatButton,
    MatIconButton,
    RouterLink,
    MatFormField,
    MatLabel,
    MatInput,
    CurrencyPipe,
    FormsModule,
    MatIcon
  ],
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss'],
})
export class OrderTotalsComponent {
  cartService = inject(CartService);
  private stripeService = inject(StripeService);
  location = inject(Location);
  code?: string;
  couponError?: string;

  applyCouponCode() {
    if (!this.code) return;

    this.couponError = undefined;

    this.cartService.applyDiscount(this.code).subscribe({
      next: async (coupon: any) => {
        const cart = this.cartService.cart();
        if (cart) {
          cart.coupon = coupon.data;
          await firstValueFrom(this.cartService.setCart(cart));
          this.code = undefined;
        }
        if (this.location.path() === '/checkout') {
          await firstValueFrom(
            this.stripeService.createOrUpdatePaymentIntent(),
          );
        }
      },
      error: () => {
        this.couponError = 'Coupon code not found or expired';
      },
    });
  }

  async removeCouponCode() {
    const cart = this.cartService.cart();
    if (!cart) return;
    if (cart.coupon) cart.coupon = undefined;
    await firstValueFrom(this.cartService.setCart(cart));
    if (this.location.path() === '/checkout') {
      await firstValueFrom(this.stripeService.createOrUpdatePaymentIntent());
    }
  }

  clearError() {
    this.couponError = undefined;
  }
}
