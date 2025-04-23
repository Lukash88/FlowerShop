import { Component } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { AccountService } from 'src/app/core/services/account.service';
import { CartItem } from 'src/app/shared/models/cart';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent {

  constructor(public cartService: CartService, public accountService: AccountService) { }
  
  getCount(items: CartItem[]) {
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}
