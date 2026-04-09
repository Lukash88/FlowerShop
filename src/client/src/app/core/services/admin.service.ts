import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { OrderParams } from 'src/app/shared/models/orderParams';
import { Pagination } from 'src/app/shared/models/pagination';
import { Order } from 'src/app/shared/models/order';
import { Product, ProductType } from 'src/app/shared/models/product';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getOrders(orderParams: OrderParams) {
    let params = new HttpParams();

    params = params.append('Page', orderParams.pageNumber);
    params = params.append('PageSize', orderParams.pageSize);

    if (orderParams.filter && orderParams.filter !== 'All') {
      params = params.append('Filters', `OrderState==${orderParams.filter}`);
    }

    return this.http.get<Pagination<Order[]>>(this.baseUrl + 'admin/orders', {
      params,
    });
  }

  getOrder(id: number) {
    return this.http.get<Order>(this.baseUrl + 'admin/orders/' + id);
  }

  refundOrder(id: number) {
    return this.http.post<Order>(this.baseUrl + 'admin/payments/refund/' + id, {});
  }

  createProduct(product: any, productType: ProductType) {
    const endpoint = this.getEndpointForType(productType);
    return this.http
      .post<any>(`${this.baseUrl}${endpoint}`, product)
      .pipe(map((response) => response.data));
  }

  updateProduct(product: any, productType: ProductType) {
    const endpoint = this.getEndpointForType(productType);
    return this.http
      .put<any>(`${this.baseUrl}${endpoint}/${product.id}`, product)
      .pipe(map((response) => response.data));
  }

  deleteProduct(id: number) {
    return this.http.delete<Product>(this.baseUrl + 'products/' + id);
  }

  private getEndpointForType(productType: ProductType): string {
    switch (productType) {
      case 'Decoration':
        return 'decorations';
      case 'Flower':
        return 'flowers';
      case 'Bouquet':
        return 'bouquets';
      default:
        throw new Error(`Unknown product type: ${productType}`);
    }
  }

  updateStock(id: number, newQuantity: number) {
    return this.http.put(this.baseUrl + 'products/update-stock/' + id, {
      newQuantity: newQuantity,
    });
  }
}
