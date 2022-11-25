import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryEnum } from '../shared/models/category';
import { IProduct } from '../shared/models/product';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;  
  products: IProduct[];  
  categories = CategoryEnum;  
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Unalphabetical', value: '-name'},
    {name: 'Price: Low to High', value: 'price'},
    {name: 'Price: High to Low', value: '-price'}    
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe((response: any) => {
      this.products = response.data.results;
      this.shopParams.pageNumber = response.data.currentPage;
      this.shopParams.pageSize = response.data.pageSize;
      this.totalCount = response.data.rowCount;
    }, error => {
      console.log(error);
    });
  }
  
  onCategorySelected(categoryName: CategoryEnum): void {
    this.shopParams.categorySelected = categoryName;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sortSelected = sort;
    this.getProducts();
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }
}