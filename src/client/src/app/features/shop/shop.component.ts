import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ShopService } from 'src/app/core/services/shop.service';
import { CategoryEnum } from 'src/app/shared/models/category';
import { Product } from 'src/app/shared/models/product';
import { ShopParams } from 'src/app/shared/models/shopParams';
import { ProductItemComponent } from './product-item/product-item.component';
import { Pagination } from 'src/app/shared/models/pagination';
@Component({
    selector: 'app-shop',
    standalone: true,
    imports: [
      CommonModule,
      FormsModule,
      MatPaginator,
      ProductItemComponent
    ],
    templateUrl: './shop.component.html',
    styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;  
  products?: Pagination<Product>; 
  categories = CategoryEnum;  
  shopParams = new ShopParams();
  totalCount = 0;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Unalphabetical', value: '-name' },
    { name: 'Price: Low to High', value: 'price' },
    { name: 'Price: High to Low', value: '-price' }    
  ];
  pageSizeOptions = [5, 10, 15, 20];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response: any) => {
        this.products = response.data.results;
        this.shopParams.pageNumber = response.data.currentPage;
        this.shopParams.pageSize = response.data.pageSize;
        this.totalCount = response.data.rowCount;
      },
      error: error => console.log(error)
    })
  }  
  
  onCategorySelected(categoryName: CategoryEnum): void {
    this.shopParams.categories = categoryName;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
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

  handlePageEvent(event: PageEvent) {
    this.shopParams.pageNumber = event.pageIndex + 1;
    this.shopParams.pageSize = event.pageSize;
    this.getProducts();
  }
}