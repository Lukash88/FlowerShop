import { CurrencyPipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from 'src/app/core/services/cart.service';
import { Product } from 'src/app/shared/models/product';

@Component({
    selector: 'app-product-item',
    standalone: true,
    imports: [
      RouterLink,
      CurrencyPipe
    ],
    templateUrl: './product-item.component.html',
    styleUrls: ['./product-item.component.scss']    
})
export class ProductItemComponent implements OnInit {
  @Input() product: Product;
  
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  addItemToCart() {
    this.cartService.addItemToCart(this.product);
  }
}