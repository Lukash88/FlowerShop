import { Component, OnInit } from '@angular/core';
import { CartService } from './core/services/cart.service';
import { AccountService } from './core/services/account.service';
import { NavBarComponent } from './layout/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [
      NavBarComponent,
      HeaderComponent,
      RouterModule
    ],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']    
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