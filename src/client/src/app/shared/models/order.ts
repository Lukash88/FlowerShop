export interface Order {
    id: number;
    buyerEmail: string;
    createdAt: string;
    shippingAddress: ShippingAddress;
    paymentSummary: PaymentSummary;
    deliveryMethod: string;
    orderItems: OrderItem[];
    subtotal: number;
    discount?: number;
    shippingPrice: number;
    total: number;
    invoice: string;
    status: string;
  }

  export interface ShippingAddress {
    name: string;
    line1: string;
    line2?: string;
    city: string;
    state: string;
    postalCode: string;
    country: string;
  }

  export interface PaymentSummary {
    last4: number;
    brand: string;
    expMonth: number;
    expYear: number;
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
    paymentSummary: PaymentSummary;
    discount?: number;
}

export class PaginationParams {
  pageNumber = 1;
  pageSize = 5;
  sort = '-createdAt';
} 
