import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatDivider } from '@angular/material/divider';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { ShopService } from 'src/app/core/services/shop.service';

@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [
    MatDivider,
    MatSelectionList,
    MatListOption,
    MatButton,
    FormsModule,
    CommonModule,
    MatSelectionList
  ],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {
  private dialogRef = inject(MatDialogRef<FiltersDialogComponent>);
  shopService = inject(ShopService);
  data = inject(MAT_DIALOG_DATA);

  selectedCategories: string[] = this.data.selectedCategories;

  onSelectionChange(event: MatSelectionListChange) {
    const selectedOptions = event.options;
    if (selectedOptions && selectedOptions.length > 0) {
      this.selectedCategories = Array.from(selectedOptions.values()).map(option => option.value);
    }
  }

  applyFilters() {
    this.dialogRef.close({
      selectedCategories: this.selectedCategories
    });
  }
}