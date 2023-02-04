export interface Product {
    id:               number;
    name:             string;
    shortDescription: string;
    longDescription:  string;
    imageUrl:         string;
    category:         string;
    price:            number;
    stockLevel:       number;
    //orderDetails:     OrderDetails;
}

export class Product implements Product {}