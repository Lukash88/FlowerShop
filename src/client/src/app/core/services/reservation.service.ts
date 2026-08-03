import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {
  Reservation } from 'src/app/shared/models/reservation';
import { ReservationParams } from 'src/app/shared/models/reservationParams';
import { Pagination } from 'src/app/shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getReservations(reservationParams: ReservationParams) {
    let params = new HttpParams();

    params = params.append('Page', reservationParams.pageNumber);
    params = params.append('PageSize', reservationParams.pageSize);

    if (reservationParams.status && reservationParams.status !== 'All') {
      params = params.append(
        'Filters',
        `ReservationStatus==${reservationParams.status}`,
      );
    }

    if (reservationParams.eventType && reservationParams.eventType !== 'All') {
      params = params.append(
        'Filters',
        `EventType==${reservationParams.eventType}`,
      );
    }

    return this.http.get<Pagination<Reservation[]>>(
      this.baseUrl + 'reservations',
      { params },
    );
  }

  getReservation(id: number) {
    return this.http.get<Reservation>(this.baseUrl + 'reservations/' + id);
  }

  addReservation(reservation: any) {
    return this.http.post(this.baseUrl + 'reservations', reservation);
  }

  updateReservation(reservation: Partial<Reservation>) {
    return this.http.put<Reservation>(
      this.baseUrl + 'reservations/' + reservation.id,
      reservation,
    );
  }

  cancelReservation(id: number) {
    return this.http.put(this.baseUrl + 'reservations/' + id + '/cancel', {});
  }
}
