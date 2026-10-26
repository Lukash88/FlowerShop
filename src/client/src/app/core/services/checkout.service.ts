import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import type { PendingReservation } from 'src/app/shared/models/reservation';
import { environment } from 'src/environments/environment';
import { map, of } from 'rxjs';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
  deliveryMethods: DeliveryMethod[] = [];
  pendingReservation = signal<PendingReservation | null>(null);

  constructor(private http: HttpClient) { }

  getDeliveryMethods() {
    if (this.deliveryMethods.length > 0) {
      return of(this.deliveryMethods);
    }
    return this.http.get<DeliveryMethod[]>(this.baseUrl + 'deliveryMethods').pipe(
      map((dm: any) => {
        const results: DeliveryMethod[] = dm.data.results;
        this.deliveryMethods = results.sort((a, b) => b.price - a.price);
        return this.deliveryMethods;
      })
    )
  }
}