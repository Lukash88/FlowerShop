import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { DatePickerComponent } from 'src/app/shared/components/date-picker/date-picker.component';
import { ReservationService } from 'src/app/core/services/reservation.service';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { Reservation, eventTypes, eventTypeLabels } from 'src/app/shared/models/reservation';

@Component({
  selector: 'app-reservation-user-edit-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    DatePickerComponent
  ],
  templateUrl: './reservation-user-edit-dialog.component.html',
})
export class ReservationUserEditDialogComponent implements OnInit {
  form!: FormGroup;
  reservation: Reservation = inject(MAT_DIALOG_DATA);
  eventTypes = eventTypes;
  eventTypeLabels = eventTypeLabels;
  today = new Date();

  private fb = inject(FormBuilder);
  private dialogRef = inject(MatDialogRef<ReservationUserEditDialogComponent>);
  private reservationService = inject(ReservationService);
  private snackbar = inject(SnackbarService);

  ngOnInit() {
    this.form = this.fb.group({
      eventType: [this.reservation.eventType, Validators.required],
      dateOfEvent: [new Date(this.reservation.dateOfEvent), Validators.required],
      eventStreet: [this.reservation.eventAddressLine1, Validators.required],
      eventStreet2: [this.reservation.eventAddressLine2 || ''],
      eventCity: [this.reservation.eventCity, Validators.required],
      eventState: [this.reservation.eventState, Validators.required],
      eventPostalCode: [this.reservation.eventPostalCode, Validators.required],
      eventCountry: [this.reservation.eventCountry, Validators.required],
      eventDescription: [this.reservation.eventDescription || ''],
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload = {
      ...this.reservation,
      eventType: this.form.value.eventType,
      dateOfEvent: this.form.value.dateOfEvent,
      eventAddressLine1: this.form.value.eventStreet,
      eventAddressLine2: this.form.value.eventStreet2,
      eventCity: this.form.value.eventCity,
      eventState: this.form.value.eventState,
      eventPostalCode: this.form.value.eventPostalCode,
      eventCountry: this.form.value.eventCountry,
      eventDescription: this.form.value.eventDescription,
    };

    this.reservationService.updateReservation(payload).subscribe({
      next: (res: any) => {
        this.snackbar.success(`Reservation details updated.`);
        this.dialogRef.close(res.data);
      },
      error: () => this.snackbar.error('Failed to update reservation details.'),
    });
  }
}
