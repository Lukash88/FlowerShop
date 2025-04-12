import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CartService } from 'src/app/cart/cart.service';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';
import { CheckoutService } from '../checkout.service';
import { take } from 'rxjs';

@Component({
    selector: 'app-checkout-delivery',
    templateUrl: './checkout-delivery.component.html',
    styleUrls: ['./checkout-delivery.component.scss'],
    standalone: false
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