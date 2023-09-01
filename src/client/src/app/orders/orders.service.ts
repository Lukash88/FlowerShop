import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Order, PaginationParams } from '../shared/models/order';
import { Pagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getOrdersForUser(paginationParams: PaginationParams) {
    let params = new HttpParams().set('Page', paginationParams.pageNumber.toString());
    params = params.set('PageSize', paginationParams.pageSize.toString());

    return this.httpClient.get<Pagination<Order[]>>(this.baseUrl + 'orders', { params });
  }

  getOrderDetailed(id: number) {
    return this.httpClient.get<Order>(this.baseUrl + 'orders/' + id);
  }
}