import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from '../../models/reservation';
import { ReservationService } from 'src/app/core/services/reservation.service';
import { CurrencyPipe, DatePipe, NgClass } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { AccountService } from 'src/app/core/services/account.service';
import { AdminService } from 'src/app/core/services/admin.service';

@Component({
  selector: 'app-reservation-detailed',
  imports: [
    DatePipe,
    CurrencyPipe,
    NgClass,
    MatCardModule,
    MatButton
  ],
  templateUrl: './reservation-detailed.component.html',
  styleUrl: './reservation-detailed.component.scss'
})
export class ReservationDetailedComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private reservationService = inject(ReservationService);
  private adminService = inject(AdminService);
  private accountService = inject(AccountService);

  reservation?: Reservation;
  buttonText = this.accountService.isAdmin() ? 'Return to Admin' : 'Return to My Reservations';

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id')!;
    const load$ = this.accountService.isAdmin()
      ? this.adminService.getReservation(id)
      : this.reservationService.getReservation(id);

    load$.subscribe({
      next: (res: any) => (this.reservation = res.data),
    });
  }

  get statusClass(): string {
    switch (this.reservation?.reservationStatus) {
      case 'Confirmed':  return 'bg-green-100 text-green-800';
      case 'Pending':    return 'bg-yellow-100 text-yellow-800';
      case 'Processing': return 'bg-blue-100 text-blue-800';
      case 'Cancelled':  return 'bg-red-100 text-red-800';
      case 'Expired':    return 'bg-gray-100 text-gray-600';
      default:           return 'bg-gray-100 text-gray-600';
    }
  }

  onReturnClick() {
    this.accountService.isAdmin()
      ? this.router.navigateByUrl('/admin')
      : this.router.navigateByUrl('/reservations');
  }
}