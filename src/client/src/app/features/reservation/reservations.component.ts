import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { ReservationListComponent } from './reservation-list/reservation-list.component';

@Component({
  selector: 'app-reservations',
  standalone: true,
  imports: [MatButtonModule, ReservationListComponent],
  templateUrl: './reservations.component.html',
})
export class ReservationsComponent {
  private router = inject(Router);

  newReservation() {
    this.router.navigateByUrl('/reservations/new');
  }
}
