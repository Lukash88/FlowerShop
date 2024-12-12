import { v4 as uuidv4 } from 'uuid';

export interface BasketType {
    id: string;
    items: BasketItem[];
    deliveryMethodId?: number;
    clientSecret?: string;
    paymentIntentId?: string;
}

export interface BasketItem {
    id: number;
    name: string;
    shortDescription: string;
    price: number;
    quantity: number;
    imageUrl: string;
    category: string;
}

export class Basket implements BasketType {
    id = uuidv4();
    items: BasketItem[] = [];
    deliveryMethodId?: number;
    clientSecret?: string;
    paymentIntentId?: string;
}

export interface BasketTotals {
    shipping: number;
    subtotal: number;
    tax: number;
    total: number;
}
