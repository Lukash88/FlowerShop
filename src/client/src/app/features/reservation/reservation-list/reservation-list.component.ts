import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ReservationService } from 'src/app/core/services/reservation.service';
import {
  Reservation,
  eventTypeLabels,
  eventTypes,
  reservationStates,
} from 'src/app/shared/models/reservation';
import { CustomTableComponent } from 'src/app/shared/components/custom-table/custom-table.component';
import { PageEvent } from '@angular/material/paginator';
import {
  ReservationParams,
  SortOptions
} from 'src/app/shared/models/reservationParams';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ReservationUserEditDialogComponent } from '../reservation-user-edit-dialog/reservation-user-edit-dialog.component';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatIcon } from '@angular/material/icon';
import {
  MatListOption,
  MatSelectionList,
  MatSelectionListChange
} from '@angular/material/list';

@Component({
  selector: 'app-reservation-list',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    CustomTableComponent,
    MatDialogModule,
    MatIcon,
    MatMenu,
    MatMenuTrigger,
    MatListOption,
    MatSelectionList
  ],
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.scss'],
})
export class ReservationListComponent implements OnInit {
  private reservationService = inject(ReservationService);
  private router = inject(Router);
  private dialog = inject(MatDialog);

  reservations: Reservation[] = [];
  totalItems = 0;
  reservationParams = new ReservationParams();
  sortOptions = SortOptions;
  eventTypeFilterOptions = ['All', ...eventTypes] as const;
  statusFilterOptions = ['All', ...reservationStates] as const;
  eventTypeLabels = eventTypeLabels;

  columns = [
    { field: 'id', header: '#' },
    { field: 'eventType', header: 'Event Type' },
    { field: 'dateOfEvent', header: 'Date', pipe: 'date' },
    { field: 'eventCity', header: 'City' },
    { field: 'reservationStatus', header: 'Status' },
    { field: 'servicePrice', header: 'Price', pipe: 'currency' },
  ];

  actions = [
    {
      label: 'View',
      icon: 'visibility',
      color: 'text-green-700',
      tooltip: 'View reservation',
      action: (row: Reservation) =>
        this.router.navigateByUrl(`/reservations/${row.id}`),
    },
    {
      label: 'Edit',
      icon: 'edit',
      color: 'text-blue-700',
      tooltip: 'Edit Event Details',
      disabled: (row: Reservation) => row.reservationStatus !== 'Pending',
      action: (row: Reservation) => this.openEditDialog(row),
    },
    {
      label: 'Cancel',
      icon: 'cancel',
      color: 'text-red-700',
      tooltip: 'Cancel reservation',
      disabled: (row: Reservation) =>
        row.reservationStatus === 'Cancelled' ||
        row.reservationStatus === 'Expired',
      action: (row: Reservation) => this.cancelReservation(row.id),
    },
  ];

  ngOnInit(): void {
    this.loadReservations();
  }

  loadReservations() {
    this.reservationService
      .getReservations(this.reservationParams)
      .subscribe((res: any) => {
        this.reservations = res.data?.results ?? [];
        this.totalItems = res.data?.rowCount ?? 0;
      });
  }

  onStatusFilterSelect(event: any) {
    this.reservationParams.status = event.value;
    this.reservationParams.pageNumber = 1;
    this.loadReservations();
  }

  onEventTypeFilterSelect(event: any) {
    this.reservationParams.eventType = event.value;
    this.reservationParams.pageNumber = 1;
    this.loadReservations();
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.reservationParams.sort = selectedOption.value;
      this.reservationParams.pageNumber = 1;
      this.loadReservations();
    }
  }

  onPageChange(event: PageEvent) {
    this.reservationParams.pageNumber = event.pageIndex + 1;
    this.loadReservations();
  }

  getStatusClass(status: string): string {
    const map: Record<string, string> = {
      Pending: 'bg-yellow-100 text-yellow-800',
      Processing: 'bg-blue-100 text-blue-800',
      Confirmed: 'bg-green-100 text-green-800',
      Cancelled: 'bg-red-100 text-red-800',
      Expired: 'bg-gray-100 text-gray-800',
    };
    return map[status] ?? 'bg-gray-100 text-gray-500';
  }

  cancelReservation(id: number) {
    this.reservationService.cancelReservation(id).subscribe({
      next: () => this.loadReservations(),
    });
  }

  openEditDialog(reservation: Reservation) {
    const dialogRef = this.dialog.open(ReservationUserEditDialogComponent, {
      width: '600px',
      data: reservation,
    });

    dialogRef.afterClosed().subscribe({
      next: (updated) => {
        if (updated) {
          this.loadReservations();
        }
      },
    });
  }
}
