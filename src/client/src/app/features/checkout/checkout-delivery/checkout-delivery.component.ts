import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';
import { take } from 'rxjs';
import { CheckoutService } from 'src/app/core/services/checkout.service';
import { CartService } from 'src/app/core/services/cart.service';

@Component({
    selector: 'app-checkout-delivery',
    standalone: true,
    templateUrl: './checkout-delivery.component.html',
    styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm?: FormGroup;
  deliveryMethods: DeliveryMethod[] = [];

  constructor(
    private checkoutService: CheckoutService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe({
      next: (dm) => {
        if (
          this.cartService.cartSource$.pipe(take(1)).subscribe({
            next: (cart) => {
              if (cart) {
                const method = this.deliveryMethods?.find(
                  (x) => x.id === cart.deliveryMethodId
                );
                this.cartService.setShippingPrice(method);
              }
            },
          })
        )
          this.deliveryMethods = dm;
      },
    });
  }

  setShippingPrice(deliveryMethod: DeliveryMethod) {
    this.cartService.setShippingPrice(deliveryMethod);
  }
}