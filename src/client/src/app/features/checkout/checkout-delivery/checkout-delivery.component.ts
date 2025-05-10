import { Component, Input, OnInit, output } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CheckoutService } from 'src/app/core/services/checkout.service';
import { CartService } from 'src/app/core/services/cart.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-checkout-delivery',
    standalone: true,
    imports: [
      ReactiveFormsModule,
      CommonModule
    ],
    templateUrl: './checkout-delivery.component.html',
    styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm?: FormGroup;
  deliveryComplete = output<boolean>();

  constructor(
    public checkoutService: CheckoutService,
    public cartService: CartService
  ) {}

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe({
      next: (methods) => {
        if (this.cartService.cart()?.deliveryMethodId) {            
          const method = methods?.find(x => x.id === this.cartService.cart()?.deliveryMethodId);
          if (method) {            
            this.cartService.selectedDelivery.set(method);
            this.deliveryComplete.emit(true);
          }
        }
      }
    });
  }
}