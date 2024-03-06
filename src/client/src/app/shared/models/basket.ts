import { v4 as uuidv4 } from 'uuid';

export interface Basket {
    id: string;
    items: BasketItem[];
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
}

export interface BasketTotals {
    shipping: number;
    subtotal: number;
    tax: number;
    total: number;
}