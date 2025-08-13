import { Pacijent } from "./pacijent";

export interface PagedList {
    dataItems: any[];
    currentPage: number;
    totalPages: number;
    pageSize: number;
    totalCount: number;
    hasPrevios: boolean;
    hasNext: boolean;
}
