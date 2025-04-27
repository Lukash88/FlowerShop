export interface Pagination<T> {
    currentPage: number;
    pageSize: number;
    pageCount: number;
    rowCount: number;
    results: T[];
}

export const PageSizeOptions: number[] =
[
    5, 
    10, 
    15, 
    20
];