import { Component, computed, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { ReservationService } from 'src/app/core/services/reservation.service';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { AccountService } from 'src/app/core/services/account.service';
import {
  eventTypes,
  reservationStates
} from 'src/app/shared/models/reservation';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ReservationSuccessComponent } from 'src/app/features/reservation/reservation-success/reservation-success.component';
import { EventComponent } from 'src/app/features/reservation/event/event.component';
import { ReservationReviewComponent } from 'src/app/features/reservation/reservation-review/reservation-review.component';
import { ReservationServiceComponent } from 'src/app/features/reservation/reservation-service/reservation-service.component';

@Component({
  selector: 'app-reservation-stepper',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    ReservationSuccessComponent,
    EventComponent,
    ReservationReviewComponent,
    ReservationServiceComponent
  ],
  templateUrl: './reservation-stepper.component.html',
  styleUrls: ['./reservation-stepper.component.scss'],
})
export class ReservationStepperComponent implements OnInit {
  private fb = inject(FormBuilder);
  private reservationService = inject(ReservationService);
  private snackbar = inject(SnackbarService);
  private accountService = inject(AccountService);
  private router = inject(Router);

  eventTypes = eventTypes;
  reservationStates = reservationStates;
  isLoading = false;
  isComplete = false;
  createdReservationId?: number;

  serviceForm!: FormGroup;
  eventForm!: FormGroup;

  today = new Date();

  selectedEventType = computed(() => this.serviceForm?.value?.eventType || '');

  ngOnInit(): void {
    this.initForms();
  }

  initForms() {
    this.serviceForm = this.fb.group({
      eventType: ['', Validators.required],
    });

    this.eventForm = this.fb.group({
      dateOfEvent: [null, Validators.required],
      eventStreet: ['', Validators.required],
      eventStreet2: [''],
      eventCity: ['', Validators.required],
      eventState: ['', Validators.required],
      eventPostalCode: ['', Validators.required],
      eventCountry: ['', Validators.required],
      eventDescription: [''],
      servicePrice: [null, Validators.min(0)]
    });
  }

  get reviewData() {
    return {
      ...this.serviceForm.value,
      ...this.eventForm.value,
    };
  }

  onSubmit() {
    const currentUser = this.accountService.currentUser();
    if (!currentUser) {
      this.router.navigate(['/account/login'], { queryParams: { returnUrl: '/reservations/new' } });
      return;
    }

    this.isLoading = true;
    
    const payload = {
      email: currentUser?.email, 
      eventType: this.serviceForm.value.eventType,
      dateOfEvent: this.eventForm.value.dateOfEvent,
      eventDescription: this.eventForm.value.eventDescription,
      servicePrice: this.eventForm.value.servicePrice,
      reservationStatus: 'Pending',
      eventAddressLine1: this.eventForm.value.eventStreet,
      eventAddressLine2: this.eventForm.value.eventStreet2,
      eventCity: this.eventForm.value.eventCity,
      eventState: this.eventForm.value.eventState,
      eventPostalCode: this.eventForm.value.eventPostalCode,
      eventCountry: this.eventForm.value.eventCountry
    };

    this.reservationService.addReservation(payload).subscribe({
      next: (res: any) => {
        this.createdReservationId = res.data?.id;
        this.isComplete = true;
        this.isLoading = false;
      },
      error: () => (this.isLoading = false),
    });
  }

  markEventFormTouched() {
    this.eventForm.markAllAsTouched();
  }

  addAnother() {
    this.isComplete = false;
    this.createdReservationId = undefined;
    this.initForms();
  }

  getEventTypeIcon(type: string): string {
    const icons: Record<string, string> = {
      Birthday: 'cake',
      BabyShower: 'child_care',
      Baptism: 'water_drop',
      BrandOfProductLaunch: 'rocket_launch',
      InternalCompanyMeeting: 'business',
      Congratulations: 'celebration',
      Anniversary: 'favorite',
      Romantic: 'favorite_border',
      JustBecause: 'auto_awesome',
      PrivateParty: 'local_bar',
      Engagement: 'diamond',
      CivilWedding: 'how_to_reg',
      ChurchWedding: 'church',
      WeddingParty: 'wine_bar',
      NewHome: 'home',
      ThankYou: 'volunteer_activism',
      Halloween: 'dark_mode',
      Funeral: 'local_florist',
    };
    return icons[type] ?? 'event';
  }

  viewReservations() {
    this.router.navigateByUrl('/reservations');
  }
}
