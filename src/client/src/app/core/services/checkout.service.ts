import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map, of } from 'rxjs';
import { DeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
  deliveryMethods: DeliveryMethod[] = [];

  constructor(private http: HttpClient) { }

  getDeliveryMethods() {
    if (this.deliveryMethods.length > 0) {
      return of(this.deliveryMethods);
    }
    return this.http.get<DeliveryMethod[]>(this.baseUrl + 'deliveryMethods').pipe(
      map((dm: any) => {
        dm = dm.data.results;
        this.deliveryMethods = dm.sort((a, b) => b.price - a.price);
        return dm;
      })
    )
  }
}