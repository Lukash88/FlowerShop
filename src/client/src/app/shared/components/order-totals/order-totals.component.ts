import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { CartTotals } from '../../models/cart';
import { CommonModule, CurrencyPipe } from '@angular/common';

@Component({
    selector: 'app-order-totals',
    standalone: true,
    imports: [
      CommonModule,
      CurrencyPipe
    ],
    templateUrl: './order-totals.component.html',
    styleUrls: ['./order-totals.component.scss'],
    
})
export class OrderTotalsComponent implements OnInit{
  cartTotals: CartTotals;

  constructor(private cartService: CartService) { }

  ngOnInit(){
    this.cartTotals = this.cartService.totals();
  }
}
