import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-reservation-review',
  standalone: true,
  imports: [DatePipe, CurrencyPipe, MatButtonModule, MatProgressSpinnerModule],
  templateUrl: './reservation-review.component.html',
})
export class ReservationReviewComponent {
  @Input() reviewData: any;
  @Input() isLoading = false;
  @Output() confirm = new EventEmitter<void>();
  @Output() back = new EventEmitter<void>();
}
