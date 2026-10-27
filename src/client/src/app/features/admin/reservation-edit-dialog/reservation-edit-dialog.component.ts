import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CurrencyPipe } from '@angular/common';
import { AdminService } from 'src/app/core/services/admin.service';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { Reservation, reservationStates } from 'src/app/shared/models/reservation';

@Component({
  selector: 'app-reservation-edit-dialog',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  templateUrl: './reservation-edit-dialog.component.html',
})
export class ReservationEditDialogComponent implements OnInit {
  form!: FormGroup;
  reservation: Reservation = inject(MAT_DIALOG_DATA);
  private fb = inject(FormBuilder);
  private dialogRef = inject(MatDialogRef<ReservationEditDialogComponent>);
  private adminService = inject(AdminService);
  private snackbar = inject(SnackbarService);

  statusOptions = reservationStates;

  ngOnInit() {
    this.form = this.fb.group({
      reservationStatus: [this.reservation.reservationStatus, Validators.required],
      servicePrice: [this.reservation.servicePrice ?? 0, [Validators.required, Validators.min(0)]]
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    const payload = {
      ...this.reservation,
      reservationStatus: this.form.value.reservationStatus,
      servicePrice: this.form.value.servicePrice,
    };

    this.adminService.updateReservation(this.reservation.id, payload).subscribe({
      next: (res: any) => {
        this.snackbar.success(`Reservation #${this.reservation.id} updated.`);
        this.dialogRef.close(res.data);
      },
      error: () => this.snackbar.error('Failed to update reservation.'),
    });
  }
}