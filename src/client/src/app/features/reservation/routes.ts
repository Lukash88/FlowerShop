import { Routes } from '@angular/router';
import { ReservationStepperComponent } from './reservation-stepper/reservation-stepper.component';
import { ReservationsComponent } from './reservations.component';
import { ReservationDetailedComponent } from 'src/app/shared/components/reservation-detailed/reservation-detailed.component';

export const reservationRoutes: Routes = [
  {
    path: '',
    component: ReservationsComponent,
    data: { breadcrumb: 'Reservations' }
  },
  {
    path: 'new',
    component: ReservationStepperComponent,
    data: { breadcrumb: 'New Reservation' }
  },
  {
    path: ':id',
    component: ReservationDetailedComponent,
    data: { breadcrumb: 'Reservation Detail' }
  },
];
