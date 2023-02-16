import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
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

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', { params });
  }  

  getProduct(id: number) {
    return this.http.get<Product>(this.baseUrl+ 'products/' + id);
  }
}