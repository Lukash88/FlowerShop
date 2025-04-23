import { CommonModule, CurrencyPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { CartService } from 'src/app/core/services/cart.service';
import { ShopService } from 'src/app/core/services/shop.service';
import { Product } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'app-product-details',
    standalone: true,
    imports: [
      CommonModule,
      CurrencyPipe
    ],
    templateUrl: './product-details.component.html',
    styleUrls: ['./product-details.component.scss']   
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
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
    if (id) this.shopService.getProduct(+id).subscribe({
      next: (product: any) => {
        this.product = product.data;
        this.bcService.set('@productDetails', product.data.name);
        this.cartService.cartSource$.pipe(take(1)).subscribe({
          next: cart => {
            const item = cart?.items.find(x => x.productId === +id);
            if (item) {
              this.quantity = item.quantity;
              this.quantityInCart = item.quantity;
            }
          }
        })
      },
      error: error => console.log(error)
    })
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 0) this.quantity--;
  }

  updateCart() {
    if (this.product) {
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
  }

  get buttonText() {
    return this.quantityInCart === 0 ? 'Add to cart' : 'Update cart';
  }
}
