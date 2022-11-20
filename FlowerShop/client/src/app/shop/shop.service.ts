import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(category?: string, search?: string, sort?: string) {
    let params = new HttpParams().set('Sorts', sort);

    if (category) {
      params = new HttpParams().set('Filters=category=', category).set('Sorts', sort);
      
      if (search) {
        params = new HttpParams().set('Filters=category==' + category + ',Name@', search).set('Sorts', sort);
      }
    }

    if (search) {
      params = new HttpParams().set('Filters=Name@', search).set('Sorts', sort);

      if (category) {
        params = new HttpParams().set('Filters=category==' + category + ',Name@', search).set('Sorts', sort);
      }
    }

    // let params = new HttpParams().set('Sorts', sort);

    // if (category) {
    //   params = params.append('Filters=category=', category)
    // }

    // if (search) {       
    //   params = params.append('Filters=Name@', search)
    // }

    return this.http.get<IProduct[]>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body
        })
      );
  }  
}