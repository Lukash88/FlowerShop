import { IProduct } from "./product";

export interface IPagination {
    currentPage: number;
    pageSize: number;
    pageCount: number;
    rowCount: number;
    data: IProduct[];
}