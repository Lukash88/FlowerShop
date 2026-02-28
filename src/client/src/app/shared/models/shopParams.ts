export class ShopParams {
    sort = 'name';
    categories: string[];
    pageNumber = 1;
    pageSize = 10;
    search = '';
}

export const SortOptions = [
    { name: 'A - Z', value: 'name' },
    { name: 'Z - A', value: '-name' },
    { name: 'Price: Low - High', value: 'price' },
    { name: 'Price: High - Low', value: '-price' },
  ];

export const PageSizeOptions: number[] =
[
    5, 
    10, 
    15, 
    20
];