export interface Pagination<T> {
    currentPage: number;
    pageSize: number;
    pageCount: number;
    rowCount: number;
    results: T;
}