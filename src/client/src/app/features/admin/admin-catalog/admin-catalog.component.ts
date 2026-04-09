import { Component, inject } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ShopService } from '../../../core/services/shop.service';
import { Product } from '../../../shared/models/product';
import { ShopParams, SortOptions } from '../../../shared/models/shopParams';
import { CustomTableComponent } from '../../../shared/components/custom-table/custom-table.component';
import { MatButtonModule } from '@angular/material/button';
import {
  MatListOption,
  MatSelectionList,
  MatSelectionListChange,
} from '@angular/material/list';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from '../../shop/filters-dialog/filters-dialog.component';
import { ProductFormComponent } from '../product-form/product-form.component';
import { AdminService } from 'src/app/core/services/admin.service';
import { firstValueFrom } from 'rxjs';
import { DialogService } from 'src/app/core/services/dialog.service';
import { Router } from '@angular/router';
import { UpdateQuantityComponent } from '../update-quantity/update-quantity.component';

@Component({
  selector: 'app-admin-catalog',
  standalone: true,
  imports: [
    CustomTableComponent,
    MatButtonModule,
    MatSelectionList,
    MatListOption,
    MatMenu,
    CommonModule,
    FormsModule,
    MatIcon,
    MatMenu,
    MatMenuTrigger,
    MatSelectionList,
    MatListOption,
  ],
  templateUrl: './admin-catalog.component.html',
  styleUrl: './admin-catalog.component.scss',
})
export class AdminCatalogComponent {
  products: Product[] = [];
  private shopService = inject(ShopService);
  private adminService = inject(AdminService);
  private dialog = inject(MatDialog);
  private dialogService = inject(DialogService);
  private router = inject(Router);
  productParams = new ShopParams();
  totalItems = 0;
  sortOptions = SortOptions;

  columns = [
    { field: 'id', header: 'No.' },
    { field: 'name', header: 'Product name' },
    { field: 'category', header: 'Category' },
    { field: 'stockLevel', header: 'Quantity' },
    { field: 'price', header: 'Price', pipe: 'currency', pipeArgs: 'USD' },
  ];

  actions = [
    {
      label: 'Edit',
      icon: 'edit',
      color: 'text-blue-700',
      tooltip: 'Edit product',
      action: (row: any) => {
        this.openEditDialog(row);
      }
    },
    {
      label: 'Delete',
      icon: 'delete',
      color: 'text-red-700',
      tooltip: 'Delete product',
      action: (row: any) => {
        this.openConfirmDialog(row.id);
      }
    },
    {
      label: 'View',
      icon: 'visibility',
      color: 'text-green-800',
      tooltip: 'View product',
      action: (row: any) => {
        this.router.navigateByUrl(`/shop/${row.id}`);
      }
    },
    {
      label: 'Update quantity',
      icon: 'add_circle',
      tooltip: 'Update quantity in stock',
      color: 'text-green-900',
      action: (row: any) => {
        this.openQuantityDialog(row);
      }
    }
  ];

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.shopService.getProducts(this.productParams).subscribe({
      next: (response: any) => {
        if (response.data) {
          this.products = response.data.results;
          this.totalItems = response.data.rowCount;
        }
      },
    });
  }

  openFiltersDialog() {
    const dialogRef = this.dialog.open(FiltersDialogComponent, {
      minWidth: '400px',
      data: {
        selectedCategories: this.productParams.categories,
      },
    });

    dialogRef.afterClosed().subscribe({
      next: (result) => {
        if (result) {
          this.productParams.categories = result.selectedCategories;
          this.productParams.pageNumber = 1;
          this.loadProducts();
        }
      },
    });
  }

  openEditDialog(product: Product) {
    const dialog = this.dialog.open(ProductFormComponent, {
      minWidth: '500px',
      data: {
        title: 'Edit product',
        product,
      },
    });

    dialog.afterClosed().subscribe({
      next: async (result) => {
        if (result?.product && result?.productType) {
          try {
            const updated = await firstValueFrom(
              this.adminService.updateProduct(
                result.product,
                result.productType,
              ),
            );
            const index = this.products.findIndex(
              (p) => p.id === result.product.id,
            );
            if (index !== -1) {
              this.products[index] = updated || result.product;
            }
          } catch (error) {
            console.error('Failed to update product:', error);
          }
        }
      },
    });
  }

  openCreateDialog() {
    const dialog = this.dialog.open(ProductFormComponent, {
      minWidth: '500px',
      data: {
        title: 'Create product',
      },
    });

    dialog.afterClosed().subscribe({
      next: async (result) => {
        if (result?.product && result?.productType) {
          try {
            const created = await firstValueFrom(
              this.adminService.createProduct(
                result.product,
                result.productType,
              ),
            );
            if (created) {
              this.products.push(created);
            }
          } catch (error) {
            console.error('Failed to create product:', error);
          }
        }
      },
    });
  }

  async openConfirmDialog(id: number) {
    const confirmed = await this.dialogService.confirm(
      'Remove product',
      'This will permanently remove the product from the catalog. Continue?',
    );
    if (confirmed) this.onDelete(id);
  }

  onDelete(id: number) {
    this.adminService.deleteProduct(id).subscribe({
      next: () => {
        this.products = this.products.filter((x) => x.id !== id);
      },
    });
  }

  openQuantityDialog(product: Product) {
    const dialog = this.dialog.open(UpdateQuantityComponent, {
      minWidth: '500px',
      data: {
        quantity: product.stockLevel,
        name: product.name,
      },
    });

    dialog.afterClosed().subscribe({
      next: async (result) => {
        if (result && result.updatedQuantity !== product.stockLevel) {
          try {
            await firstValueFrom(
              this.adminService.updateStock(product.id, result.updatedQuantity),
            );
            const index = this.products.findIndex((p) => p.id === product.id);
            if (index !== -1) {
              this.products[index] = {
                ...this.products[index],
                stockLevel: result.updatedQuantity,
              };
            }
          } catch (error) {
            console.error('Failed to update stock:', error);
          }
        }
      },
    });
  }

  onPageChange(event: PageEvent) {
    this.productParams.pageNumber = event.pageIndex + 1;
    this.productParams.pageSize = event.pageSize;
    this.loadProducts();
  }

  onCategorySelected(event: MatSelectionListChange) {
    const selectedOptions = event.options;
    if (selectedOptions && selectedOptions.length > 0) {
      this.productParams.categories = Array.from(selectedOptions.values()).map(
        (option) => option.value,
      );
      this.loadProducts();
    }
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.productParams.sort = selectedOption.value;
      this.productParams.pageNumber = 1;
      this.loadProducts();
    }
  }

  onSearchChange() {
    this.productParams.pageNumber = 1;
    this.loadProducts();
  }

  onReset() {
    this.productParams = new ShopParams();
    this.loadProducts();
  }
}
