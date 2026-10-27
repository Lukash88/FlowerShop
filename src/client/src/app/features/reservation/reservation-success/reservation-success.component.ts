import { Component, Input } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reservation-success',
  standalone: true,
  imports: [DatePipe, CurrencyPipe, MatButtonModule, MatIconModule],
  templateUrl: './reservation-success.component.html',
})
export class ReservationSuccessComponent {
  @Input() reviewData: any;
  @Input() createdReservationId?: number;

  constructor(private router: Router) {}

  addAnother() {
    this.router.navigateByUrl('/reservations/new');
  }

  viewReservations() {
    this.router.navigateByUrl('/reservations');
  }
}