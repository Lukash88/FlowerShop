import { Address } from "./user";

export interface Order {
    id: number;
    buyerEmail: string;
    createdAt: string;
    shipToAddress: Address;
    deliveryMethod: string;
    orderItems: OrderItem[];
    subtotal: number;
    shippingPrice: number;
    total: number;
    invoice: string;
    status: string;
  }
  
export interface OrderItem {
    productId: number;
    productName: string;
    imageUrl: string;
    price: number;
    quantity: number;
  }

export interface OrderToCreate {
    basketId: string;
    deliveryMethodId: number;
    shipToAddress: Address;
}

export class PaginationParams {
  pageNumber = 1;
  pageSize = 5;
} 