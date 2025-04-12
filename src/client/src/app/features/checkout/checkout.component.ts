import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BasketService } from 'src/app/basket/basket.service';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
    selector: 'app-checkout',
    templateUrl: './checkout.component.html',
    styleUrls: ['./checkout.component.scss'],
    standalone: false
})
export class CheckoutComponent implements OnInit {

  constructor(private fb: FormBuilder, private accountService: AccountService,
    private basketService: BasketService) {}

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
    const cart = this.basketService.getCurrentBasketValue();
    if (cart && cart.deliveryMethodId) {
      this.checkoutForm.get('deliveryForm')?.get('deliveryMethod')
        ?.patchValue(cart.deliveryMethodId.toString());
    }
  }
 }