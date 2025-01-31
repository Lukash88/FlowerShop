import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
    selector: 'app-checkout-review',
    templateUrl: './checkout-review.component.html',
    styleUrls: ['./checkout-review.component.scss'],
    standalone: false
})
export class CheckoutReviewComponent {
  @Input() appStepper?: CdkStepper;

  constructor(private basketService: BasketService) { }

  createPaymentIntent(){
    this.basketService.createPaymentIntent().subscribe({
      next: () => {
        console.log('Payment intent created');
        this.appStepper?.next();
      },
      error: error => console.log(error.message)
    });
  }
}
