import { CurrencyPipe } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from 'src/app/core/services/cart.service';
import { Product } from 'src/app/shared/models/product';
import { MatCard, MatCardActions, MatCardContent } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';

@Component({
    selector: 'app-product-item',
    standalone: true,
    imports: [
      MatCard,
      MatCardContent,
      MatCardActions,
      MatIcon,
      CurrencyPipe,
      MatButton,
      RouterLink
    ],
    templateUrl: './product-item.component.html',
    styleUrls: ['./product-item.component.scss']    
})
export class ProductItemComponent {
  @Input() product?: Product;
  cartService = inject(CartService);
}