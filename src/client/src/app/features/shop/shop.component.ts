import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { ShopService } from 'src/app/core/services/shop.service';
import { Product } from 'src/app/shared/models/product';
import { PageSizeOptions, ShopParams, SortOptions } from 'src/app/shared/models/shopParams';
import { ProductItemComponent } from './product-item/product-item.component';
import { Pagination } from 'src/app/shared/models/pagination';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { MatIcon } from '@angular/material/icon-module.d-BeibE7j0';
import { MatDialog } from '@angular/material/dialog.d-Dvsbu-0E';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';

@Component({
    selector: 'app-shop',
    standalone: true,
    imports: [
      CommonModule,
      FormsModule,
      MatPaginator,
      MatIcon,
      MatMenu,
      MatMenuTrigger,
      MatSelectionList,
      MatListOption,
      ProductItemComponent
    ],
    templateUrl: './shop.component.html',
    styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;  
  products?: Pagination<Product>;
  shopParams = new ShopParams();
  totalCount = 0;
  sortOptions = SortOptions;
  pageSizeOptions = PageSizeOptions;

  constructor(private shopService: ShopService, private dialogService: MatDialog) { }

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

  openFiltersDialog() {
    const dialogRef = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '400px',
      data: {
        selectedCategories: this.shopParams.categories
      }
    });
    dialogRef.afterClosed().subscribe({
      next: result => {
        if (result) {
          this.shopParams.categories = result.selectedCategories;
          this.shopParams.pageNumber = 1;
          console.log('Shop params: =>');
          console.log(this.shopParams.categories);
          this.getProducts();          
        }
      }
    })
  }
  
  onCategorySelected(event: MatSelectionListChange) {
    const selectedOptions = event.options;
    if (selectedOptions && selectedOptions.length > 0) {
      this.shopParams.categories = Array.from(selectedOptions.values())
        .map(option => option.value);
      this.getProducts();
    }
  }

  onSortChanged(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.shopParams.sort = selectedOption.value;
      this.shopParams.pageNumber = 1;
      this.getProducts();
      console.log(this.shopParams.sort);
    }
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