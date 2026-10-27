import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation, eventTypeLabels } from '../../models/reservation';
import { ReservationService } from 'src/app/core/services/reservation.service';
import { CommonModule, CurrencyPipe, DatePipe, NgClass } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { AccountService } from 'src/app/core/services/account.service';
import { AdminService } from 'src/app/core/services/admin.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ReservationUserEditDialogComponent } from 'src/app/features/reservation/reservation-user-edit-dialog/reservation-user-edit-dialog.component';
@Component({
  selector: 'app-reservation-detailed',
  imports: [
    CommonModule,
    DatePipe,
    CurrencyPipe,
    NgClass,
    MatCardModule,
    MatButton,
    MatDialogModule
  ],
  templateUrl: './reservation-detailed.component.html',
  styleUrl: './reservation-detailed.component.scss',
})
export class ReservationDetailedComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private reservationService = inject(ReservationService);
  private adminService = inject(AdminService);
  private accountService = inject(AccountService);
  private dialog = inject(MatDialog);

  reservation?: Reservation;
  eventTypeLabels = eventTypeLabels;
  buttonText = this.accountService.isAdmin()
    ? 'Return to Admin'
    : 'Return to My Reservations';

  ngOnInit() {
    this.loadReservation();
  }

  loadReservation() {
    const id = +this.route.snapshot.paramMap.get('id')!;
    if (isNaN(id)) {
      this.router.navigateByUrl('/not-found');
      return;
    }
    const load$ = this.accountService.isAdmin()
      ? this.adminService.getReservation(id)
      : this.reservationService.getReservation(id);

    load$.subscribe({
      next: (res: any) => (this.reservation = res.data),
    });
  }

  get statusClass(): string {
    switch (this.reservation?.reservationStatus) {
      case 'Confirmed':
        return 'bg-green-100 text-green-800';
      case 'Pending':
        return 'bg-yellow-100 text-yellow-800';
      case 'Processing':
        return 'bg-blue-100 text-blue-800';
      case 'Cancelled':
        return 'bg-red-100 text-red-800';
      case 'Expired':
        return 'bg-gray-100 text-gray-600';
      default:
        return 'bg-gray-100 text-gray-600';
    }
  }

  get canEdit(): boolean {
    return (
      !this.accountService.isAdmin() &&
      this.reservation?.reservationStatus === 'Pending'
    );
  }

  openEditDialog() {
    if (!this.reservation) return;

    const dialogRef = this.dialog.open(ReservationUserEditDialogComponent, {
      width: '600px',
      data: this.reservation,
    });

    dialogRef.afterClosed().subscribe({
      next: (updated) => {
        if (updated) {
          this.loadReservation();
        }
      },
    });
  }

  onReturnClick() {
    this.accountService.isAdmin()
      ? this.router.navigateByUrl('/admin')
      : this.router.navigateByUrl('/reservations');
  }
}
