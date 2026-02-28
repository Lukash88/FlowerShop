import { Component, OnInit, output } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CheckoutService } from 'src/app/core/services/checkout.service';
import { CartService } from 'src/app/core/services/cart.service';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '@angular/material/radio';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';
import { firstValueFrom } from 'rxjs';

@Component({
    selector: 'app-checkout-delivery',
    standalone: true,
    imports: [
      ReactiveFormsModule,
      CommonModule,
      MatRadioModule
    ],
    templateUrl: './checkout-delivery.component.html',
    styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
    deliveryComplete = output<boolean>();
  
    constructor(public checkoutService: CheckoutService, public cartService: CartService) {}
  
    ngOnInit(): void {
      this.checkoutService.getDeliveryMethods().subscribe({
        next: methods => {
          if (this.cartService.cart()?.deliveryMethodId) {            
            const method = methods.find(x => x.id === this.cartService.cart()?.deliveryMethodId);
            if (method) {            
              this.cartService.selectedDelivery.set(method);
              this.deliveryComplete.emit(true);
            }
          }
        }
      });
    }
  
    async updateDeliveryMethod(method: DeliveryMethod) {
      this.cartService.selectedDelivery.set(method);
      const cart = this.cartService.cart();
      if (cart) {
        cart.deliveryMethodId = method.id;
        await firstValueFrom(this.cartService.setCart(cart));
        this.deliveryComplete.emit(true);
      }
    }
}
