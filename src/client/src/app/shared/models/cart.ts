import { nanoid } from 'nanoid';

export type CartType = {
    id: string;
    items: CartItem[];
    deliveryMethodId?: number;
    clientSecret?: string;
    paymentIntentId?: string;
    coupon?: Coupon;
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
    coupon?: Coupon;
}

export type Coupon = {
    name: string;
    amountOff?: number;
    percentOff?: number;
    promotionCode: string;
    couponId: string;
}
