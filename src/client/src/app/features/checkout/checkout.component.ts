import { CdkStepperModule } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AccountService } from 'src/app/core/services/account.service';
import { CartService } from 'src/app/core/services/cart.service';
import { StepperComponent } from 'src/app/shared/components/stepper/stepper.component';
import { CheckoutAddressComponent } from './checkout-address/checkout-address.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';
import { CheckoutDeliveryComponent } from './checkout-delivery/checkout-delivery.component';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';
import { OrderTotalsComponent } from 'src/app/shared/components/order-totals/order-totals.component';

@Component({
    selector: 'app-checkout',
    standalone: true,
    imports: [
      CdkStepperModule,
      StepperComponent,
      CheckoutAddressComponent,
      CheckoutReviewComponent,
      CheckoutDeliveryComponent,
      CheckoutPaymentComponent,
      OrderTotalsComponent
    ],
    templateUrl: './checkout.component.html',
    styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  constructor(private fb: FormBuilder, private accountService: AccountService,
    private cartService: CartService) {}

  ngOnInit(): void {
    this.getAddressFormValues();
    this.getDeliveryMethodValue();
  }

  checkoutForm = this.fb.group({
    addressForm: this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      postalCode: ['', Validators.required],
      city: ['', Validators.required],
    }),
    deliveryForm: this.fb.group({
      deliveryMethod: ['', Validators.required]
    }),
    paymentForm: this.fb.group({
      nameOnCard: ['', Validators.required]
    })
  })

  getAddressFormValues() {
    this.accountService.getUserAddress().subscribe({
      next: (address: any) => {
        address && this.checkoutForm.get('addressForm')?.patchValue(address.data)
      }
    });
  }

  getDeliveryMethodValue() {
    const cart = this.cartService.cart();
    if (cart && cart.deliveryMethodId) {
      this.checkoutForm.get('deliveryForm')?.get('deliveryMethod')
        ?.patchValue(cart.deliveryMethodId.toString());
    }
  }
 }