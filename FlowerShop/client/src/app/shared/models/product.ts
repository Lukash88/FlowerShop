export interface IProduct {
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