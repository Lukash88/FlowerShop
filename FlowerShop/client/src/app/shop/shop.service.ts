import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams().set('Sorts', shopParams.sort);

    if (shopParams.categorySelected) {
      params = new HttpParams().set('Filters=category=', shopParams.categorySelected).set('Sorts', shopParams.sortSelected);
      
      if (shopParams.search) {
        params = new HttpParams().set('Filters=category==' + shopParams.categorySelected + ',Name@', shopParams.search).set('Sorts', shopParams.sortSelected);
      }
    }

    if (shopParams.search) {
      params = new HttpParams().set('Filters=Name@', shopParams.search).set('Sorts', shopParams.sortSelected);

      if (shopParams.categorySelected) {
        params = new HttpParams().set('Filters=category==' + shopParams.categorySelected + ',Name@', shopParams.search).set('Sorts', shopParams.sortSelected);
      }
    }

    params = params.set('Page', shopParams.pageNumber.toString());
    params = params.set('PageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }  

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl+ 'products/' + id);
  }
}