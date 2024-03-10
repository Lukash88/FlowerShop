import { Component } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent {

  constructor(private basketService: BasketService) { }

  createPaymentIntent(){
    this.basketService.createPaymentIntent().subscribe({
      next: () => console.log('success creating payment intent'),
      error: error => console.log(error.message)
    });
  }
}
