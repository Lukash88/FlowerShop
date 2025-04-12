import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from 'src/app/shared/models/pagination';
import { Product } from 'src/app/shared/models/product';
import { ShopParams } from 'src/app/shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams().set('Sorts', shopParams.sort);

    if (shopParams.categories) {
      params = new HttpParams().append('Filters=category=', shopParams.categories.join('|')).set('Sorts', shopParams.sort);

      
      if (shopParams.search) {
        params = new HttpParams().set('Filters=category==' + shopParams.categories + ',Name@', shopParams.search).set('Sorts', shopParams.sort);
      }
    }

    if (shopParams.search) {
      params = new HttpParams().set('Filters=Name@', shopParams.search).set('Sorts', shopParams.sort);

      if (shopParams.categories) {
        params = new HttpParams().set('Filters=category==' + shopParams.categories + ',Name@', shopParams.search).set('Sorts', shopParams.sort);
      }
    }

    params = params.set('Page', shopParams.pageNumber.toString());
    params = params.set('PageSize', shopParams.pageSize.toString());

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', { params });
  }  

  getProduct(id: number) {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }
}