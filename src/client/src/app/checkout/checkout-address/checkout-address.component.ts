import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AccountService } from 'src/app/core/services/account.service';
import { CartService } from 'src/app/core/services/cart.service';

@Component({
    selector: 'app-checkout-address',
    standalone: true,
    templateUrl: './checkout-address.component.html',
    styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent {
  @Input() checkoutForm?: FormGroup;

  constructor(private accountService: AccountService, private cartService: CartService) {}
  
  saveUserAddress() {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm')?.value).subscribe({
      next: () => {
        this.checkoutForm.get('addressForm')?.reset(this.checkoutForm.get('addressForm')?.value);
      }
    });
  }
}
