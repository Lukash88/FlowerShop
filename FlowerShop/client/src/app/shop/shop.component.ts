import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryEnum } from '../shared/models/category';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  products: IProduct[];
  categorySelected: string;
  categories = CategoryEnum;
  search: string;
  sortSelected = 'name';
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
    this.shopService.getProducts(this.categorySelected, this.search, this.sortSelected).subscribe((response: any) => {
      this.products = response.data.$values;
    }, error => {
      console.log(error);
    });
  }
  
  onCategorySelected(categoryName: CategoryEnum): void {
    this.categorySelected = categoryName;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.sortSelected = sort;
    this.getProducts();
  }

  onSearch() {
    this.search = this.searchTerm.nativeElement.value;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.search = '';
    this.getProducts();
  }
}