import { Component, inject } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { CartTotals } from '../../models/cart';
import { CurrencyPipe, Location } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-order-totals',
    standalone: true,
    imports: [
      MatButton,
      RouterLink,
      CurrencyPipe,
      FormsModule
    ],
    templateUrl: './order-totals.component.html',
    styleUrls: ['./order-totals.component.scss'],
    
})
export class OrderTotalsComponent {
  cartTotals: CartTotals;
  cartService = inject(CartService);
  location = inject(Location);

}
