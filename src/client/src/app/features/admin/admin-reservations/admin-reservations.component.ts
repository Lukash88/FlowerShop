import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/services/admin.service';
import { DialogService } from 'src/app/core/services/dialog.service';
import { ReservationService } from 'src/app/core/services/reservation.service';
import {
  Reservation,
  reservationStates,
  eventTypes,
  eventTypeLabels
} from 'src/app/shared/models/reservation';
import { CustomTableComponent } from 'src/app/shared/components/custom-table/custom-table.component';
import { ReservationParams } from 'src/app/shared/models/reservationParams';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ReservationEditDialogComponent } from '../reservation-edit-dialog/reservation-edit-dialog.component';

@Component({
  selector: 'app-admin-reservations',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatSelectModule,
    CustomTableComponent,
    MatDialogModule
  ],
  templateUrl: './admin-reservations.component.html',
  styleUrl: './admin-reservations.component.scss',
})
export class AdminReservationsComponent implements OnInit {
  private adminService = inject(AdminService);
  private reservationService = inject(ReservationService);
  private dialogService = inject(DialogService);
  private router = inject(Router);
  private dialog = inject(MatDialog);

  reservations: Reservation[] = [];
  totalItems = 0;
  reservationParams = new ReservationParams();
  eventTypeFilterOptions = ['All', ...eventTypes] as const;
  statusFilterOptions = ['All', ...reservationStates] as const;
  eventTypeLabels = eventTypeLabels;

  columns = [
    { field: 'id', header: 'No.' },
    { field: 'email', header: 'Email' },
    { field: 'eventType', header: 'Event Type' },
    { field: 'dateOfEvent', header: 'Date of Event', pipe: 'date' },
    { field: 'eventCity', header: 'City' },
    { field: 'reservationStatus', header: 'Status' },
    { field: 'servicePrice', header: 'Price', pipe: 'currency' },
  ];

  actions = [
    {
      label: 'View',
      icon: 'visibility',
      color: 'text-green-700',
      tooltip: 'View Reservation',
      action: (row: Reservation) =>
        this.router.navigateByUrl(`/reservations/${row.id}`),
    },
    {
      label: 'Edit',
      icon: 'edit',
      color: 'text-blue-700',
      tooltip: 'Edit Reservation',
      action: (row: Reservation) => {
        this.openEditDialog(row);
      },
    },
    {
      label: 'Cancel',
      icon: 'cancel',
      color: 'text-red-700',
      tooltip: 'Cancel Reservation',
      disabled: (row: Reservation) =>
        row.reservationStatus === 'Cancelled' ||
        row.reservationStatus === 'Expired',
      action: (row: Reservation) => this.openCancelDialog(row),
    }
  ];

  ngOnInit(): void {
    this.loadReservations();
  }

  loadReservations() {
    this.adminService.getReservations(this.reservationParams).subscribe({
      next: (response: any) => {
        if (response.data) {
          this.reservations = response.data.results;
          this.totalItems = response.data.rowCount;
        }
      },
    });
  }

  onPageChange(event: PageEvent) {
    this.reservationParams.pageNumber = event.pageIndex + 1;
    this.reservationParams.pageSize = event.pageSize;
    this.loadReservations();
  }

  onStatusFilterSelect(event: MatSelectChange) {
    this.reservationParams.status = event.value;
    this.reservationParams.pageNumber = 1;
    this.loadReservations();
  }

  onEventTypeFilterSelect(event: MatSelectChange) {
    this.reservationParams.eventType = event.value;
    this.reservationParams.pageNumber = 1;
    this.loadReservations();
  }

  async openCancelDialog(reservation: Reservation) {
    const confirmed = await this.dialogService.confirm(
      `Cancel reservation #${reservation.id}?`,
      'This action cannot be undone.',
    );
    if (confirmed) this.cancelReservation(reservation.id);
  }

  cancelReservation(id: number) {
    this.reservationService.cancelReservation(id).subscribe({
      next: () => this.loadReservations(),
    });
  }

  openEditDialog(reservation: Reservation) {
    const dialogRef = this.dialog.open(ReservationEditDialogComponent, {
      width: '500px',
      data: reservation,
    });

    dialogRef.afterClosed().subscribe({
      next: (updated: any) => {
        if (updated) {
          this.loadReservations();
        }
      },
    });
  }
}
