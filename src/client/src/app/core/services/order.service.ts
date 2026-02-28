import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import {
  Order,
  OrderToCreate,
  PaginationParams
} from 'src/app/shared/models/order';
import { Pagination } from 'src/app/shared/models/pagination';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;
  orderComplete = false;

  constructor(private httpClient: HttpClient) {}

  getOrdersForUser(paginationParams: PaginationParams) {
    let params = new HttpParams().set('Page', paginationParams.pageNumber.toString());
    params = params.append('Sorts', paginationParams.sort);
    params = params.set('PageSize', paginationParams.pageSize.toString());

    return this.httpClient.get<Pagination<Order[]>>(this.baseUrl + 'orders/userOrders', { params });
  }

  getOrderDetailed(id: number) {
    return this.httpClient.get<Order>(this.baseUrl + 'orders/userOrders/' + id);
  }

  createOrder(orderToCreate: OrderToCreate) {
    return this.httpClient.post<Order>(this.baseUrl + 'orders', orderToCreate).pipe(
      map((response: any) => response.data
    ));
  }
}
