import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoryList } from 'src/app/shared/models/category';
import { Pagination } from 'src/app/shared/models/pagination';
import { Product } from 'src/app/shared/models/product';
import { ShopParams } from 'src/app/shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  categories = CategoryList;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.categories?.length && shopParams.search) {
      params = params.append('Filters=category==', shopParams.categories.join('|') + ',Name@' + shopParams.search);
    } else if (shopParams.categories?.length) {
      params = params.append('Filters=category==', shopParams.categories.join('|'));
    } else if (shopParams.search) {
      params = params.append('Filters=Name@', shopParams.search);
    }

    params = params.append('Sorts', shopParams.sort);
    params = params.append('Page', shopParams.pageNumber.toString());
    params = params.append('PageSize', shopParams.pageSize.toString());

    return this.http.get<Pagination<Product>>(this.baseUrl + 'products', { params });;
  }

  getProduct(id: number) {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }
}