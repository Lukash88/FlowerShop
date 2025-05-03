import { nanoid } from 'nanoid';

export type CartType = {
    id: string;
    items: CartItem[];
    deliveryMethodId?: number;
    clientSecret?: string;
    paymentIntentId?: string;
}

export type CartItem = {
    productId: number;
    productName: string;
    shortDescription: string;
    price: number;
    quantity: number;
    imageUrl: string;
    category: string;
}

export class Cart implements CartType {
    id = nanoid();
    items: CartItem[] = [];
    deliveryMethodId?: number;
    clientSecret?: string;
    paymentIntentId?: string;
}

export type CartTotals = {
    shipping: number;
    subtotal: number;
    tax: number;
    total: number;
}
