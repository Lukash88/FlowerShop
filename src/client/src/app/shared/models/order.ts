import { Address } from "./user";

export interface Order {
    id: number;
    buyerEmail: string;
    createdAt: string;
    shippingAddress: ShippingAddress
    deliveryMethod: string;
    orderItems: OrderItem[];
    subtotal: number;
    shippingPrice: number;
    total: number;
    invoice: string;
    status: string;
  }

  export interface ShippingAddress {
    name: string
    line1: string
    line2?: string
    city: string
    state: string
    postalCode: string
    country: string
  }
  
export interface OrderItem {
    productId: number;
    productName: string;
    imageUrl: string;
    price: number;
    quantity: number;
  }

export interface OrderToCreate {
    cartId: string;
    deliveryMethodId: number;
    shippingAddress: ShippingAddress;
}

export class PaginationParams {
  pageNumber = 1;
  pageSize = 5;
} 