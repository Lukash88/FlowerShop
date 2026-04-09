export interface Product {
    id: number;
    name: string;
    category: string;
    shortDescription: string;
    longDescription: string;
    imageUrl: string;
    imageThumbnailUrl: string;
    price: number;
    stockLevel: number;
    productType?: ProductType;
}

export class Product implements Product {}

export type ProductType = 'Decoration' | 'Flower' | 'Bouquet';
export const ProductTypeList: ProductType[] = [
    'Decoration',
    'Flower',
    'Bouquet'
];

export interface Decoration extends Product {
    role: DecorationRole;
}

export type DecorationRole = 'ToRent' | 'ToBuy';
export const DecorationRoleList: string[] = 
[
    'ToRent',
    'ToBuy'
];

export interface Flower extends Product {
    flowerType: FlowerType;
    lengthInCm?: number;
    color: FlowerColor;
}

export type FlowerType = 'Rose' | 'Tulip' | 'Lily' | 'Sunflower'
    | 'Orchid' | 'Daisy';
export const FlowerTypeList: FlowerType[] =
[
    'Rose',
    'Tulip',
    'Lily',
    'Sunflower',
    'Orchid',
    'Daisy'
];

export type FlowerColor = 'Red' | 'White' | 'Yellow' | 'Pink'
    | 'Purple' | 'Orange' | 'Mixed';
export const FlowerColorList: FlowerColor[] =
[
    'Red',
    'White',
    'Yellow',
    'Pink',
    'Purple',
    'Orange',
    'Mixed'
];

export interface Bouquet extends Product {
    occasion: Occasion;
    typeOfArrangement: TypeOfFlowerArrangement;
    decorationWay: DecorationWay;
}

export type Occasion = 'Birthday' | 'Wedding' | 'Anniversary'
    | 'Funeral' | 'Valentines' | 'Mothers_Day' | 'Other';
export const OccasionList: Occasion[] =
[
    'Birthday',
    'Wedding',
    'Anniversary',
    'Funeral',
    'Valentines',
    'Mothers_Day',
    'Other'
];

export type TypeOfFlowerArrangement = 'HandTied' | 'Vase' | 'Basket'
    | 'Box' | 'Wreath';
export const TypeOfFlowerArrangementList: TypeOfFlowerArrangement[] =
[
    'HandTied',
    'Vase',
    'Basket',
    'Box',
    'Wreath'
];

export type DecorationWay = 'Ribbon' | 'Paper' | 'Fabric' | 'Natural' | 'Mixed';
export const DecorationWayList: DecorationWay[] =
[
    'Ribbon',
    'Paper',
    'Fabric',
    'Natural',
    'Mixed'
];

export type CreateDecorationDto = Omit<Decoration, 'id'>;
export type CreateFlowerDto = Omit<Flower, 'id'>;
export type CreateBouquetDto = Omit<Bouquet, 'id'>;
export type CreateProductDto = CreateDecorationDto | CreateFlowerDto | CreateBouquetDto;