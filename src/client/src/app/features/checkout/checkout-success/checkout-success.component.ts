import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { Order } from 'src/app/shared/models/order';
import { AddressPipe } from "../../../shared/pipes/address.pipe";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";

@Component({
  selector: 'app-checkout-success',
  standalone: true,
  imports: [
    RouterModule,
    MatButton,
    DatePipe,
    AddressPipe,
    CurrencyPipe,
    MatProgressSpinnerModule
  ],
  templateUrl: './checkout-success.component.html',
  styleUrls: ['./checkout-success.component.scss']
})
export class CheckoutSuccessComponent {
  order?: Order;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.order =
      (navigation?.extras?.state as { order?: Order })?.order
      ?? (history.state as { order?: Order })?.order;
  }
}