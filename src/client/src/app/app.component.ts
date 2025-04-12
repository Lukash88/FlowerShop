import { Component, OnInit } from '@angular/core';
import { CartService } from './cart/cart.service';
import { AccountService } from './account/account.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    standalone: false
})
export class AppComponent implements OnInit {
  title = 'FlowerShop';
  
  constructor(private cartService: CartService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadCart();
    this.loadCurrentUser();
  }  

  loadCart() {
    const cartId = localStorage.getItem('cart_id');
    if (cartId) this.cartService.getCart(cartId);
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe();
  }
}