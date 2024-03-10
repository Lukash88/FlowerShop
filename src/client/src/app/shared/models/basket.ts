import { v4 as uuidv4 } from 'uuid';

export interface Basket {
    id: string;
    items: BasketItem[];
    deliveryMethodId?: number;
    shippingPrice: number;
    clientSecret?: string;
    paymentIntentId?: string;
}

export interface BasketItem {
    id: number;
    name: string;
    // description: string;
    shortDescription: string;
    price: number;
    quantity: number;
    imageUrl: string;
    category: string;
}

export class Basket implements Basket {
    id = uuidv4();
    items: BasketItem[] = [];
    shippingPrice = 0;
}

export interface BasketTotals {
    shipping: number;
    subtotal: number;
    tax: number;
    total: number;
}