import { CommonModule, CurrencyPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { ActivatedRoute } from '@angular/router';
import { CartService } from 'src/app/core/services/cart.service';
import { ShopService } from 'src/app/core/services/shop.service';
import { Product } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'app-product-details',
    standalone: true,
    imports: [
      CommonModule,
      CurrencyPipe,
      FormsModule,
      MatIcon,
      MatFormField,
      MatLabel,
      MatButton,
      MatInput
    ],
    templateUrl: './product-details.component.html',
    styleUrls: ['./product-details.component.scss']   
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;
  quantity = 1;
  quantityInCart = 0;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService, private cartService: CartService) { 
      this.bcService.set('@productDetails',  ' ');
    }

  ngOnInit(): void {
    this.loadProduct();
  }    

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.shopService.getProduct(+id).subscribe({
      next: (product: any) => {
        this.product = product.data;
        this.bcService.set('@productDetails', product.data.name);
        this.updateQuantityInCart();
      },
      error: error => console.log(error)
    })
  }

  private updateQuantityInCart() {
    this.quantityInCart = this.cartService.cart()?.items
      .find(x => x.productId === this.product?.id)?.quantity || 0;
    this.quantity = this.quantityInCart || 1;
  }

  updateCart() {
    if (!this.product) return;
    if (this.quantity > this.quantityInCart) {
      const itemsToAdd = this.quantity - this.quantityInCart;
      this.quantityInCart += itemsToAdd;
      this.cartService.addItemToCart(this.product, itemsToAdd);
    } else {
      const itemsToRemove = this.quantityInCart - this.quantity;
      this.quantityInCart -= itemsToRemove;
      this.cartService.removeItemFromCart(this.product.id, itemsToRemove);
    }  
  }

  get buttonText() {
    return this.quantityInCart > 0 ? 'Update cart' : 'Add to cart';
  }
}