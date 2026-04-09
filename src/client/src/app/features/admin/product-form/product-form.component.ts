import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  ProductType,
  ProductTypeList,
  DecorationRoleList,
  FlowerTypeList,
  FlowerColorList,
  OccasionList,
  TypeOfFlowerArrangementList,
  DecorationWayList,
} from '../../../shared/models/product';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { TextAreaComponent } from 'src/app/shared/components/text-area/text-area.component';
import { CategoryList } from 'src/app/shared/models/category';
import { SelectInputComponent } from 'src/app/shared/components/select-input/select-input.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [
    CommonModule,
    TextInputComponent,
    MatButtonModule,
    MatDialogModule,
    ReactiveFormsModule,
    TextAreaComponent,
    SelectInputComponent
  ],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.scss',
})
export class ProductFormComponent implements OnInit {
  productForm!: FormGroup;
  data = inject(MAT_DIALOG_DATA);
  private fb = inject(FormBuilder);
  private dialogRef = inject(MatDialogRef<ProductFormComponent>);
  categories = CategoryList;
  productTypes = ProductTypeList;
  roles = DecorationRoleList;
  flowerTypes = FlowerTypeList;
  flowerColors = FlowerColorList;
  occasions = OccasionList;
  arrangementTypes = TypeOfFlowerArrangementList;
  decorationWays = DecorationWayList;
  selectedProductType: ProductType | null = null;

  ngOnInit(): void {
    this.initializeForm();

    if (this.data.product) {
      this.selectedProductType = this.detectProductType(this.data.product);
      this.addTypeSpecificControls(this.selectedProductType);

      this.productForm.patchValue({
        ...this.data.product,
        productType: this.selectedProductType,
      });
    }
  }

  initializeForm() {
    this.productForm = this.fb.group({
      productType: ['', Validators.required],
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      shortDescription: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(200),
        ],
      ],
      longDescription: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(500),
        ],
      ],
      imageUrl: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(500),
        ],
      ],
      imageThumbnailUrl: [''],
      category: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      stockLevel: [0, [Validators.required, Validators.min(0)]],
    });
  }

  onProductTypeChange(event: any) {
    const productType = event.value || event;
    this.selectedProductType = productType;
    this.removeTypeSpecificControls();
    this.addTypeSpecificControls(productType);
  }

  private addTypeSpecificControls(productType: ProductType) {
    switch (productType) {
      case 'Decoration':
        if (!this.productForm.contains('role')) {
          this.productForm.addControl(
            'role',
            this.fb.control(this.data.product?.role || '', Validators.required),
          );
        }
        break;

      case 'Flower':
        if (!this.productForm.contains('flowerType')) {
          this.productForm.addControl(
            'flowerType',
            this.fb.control(
              this.data.product?.flowerType || '',
              Validators.required,
            ),
          );
        }
        if (!this.productForm.contains('color')) {
          this.productForm.addControl(
            'color',
            this.fb.control(
              this.data.product?.color || '',
              Validators.required,
            ),
          );
        }
        if (!this.productForm.contains('lengthInCm')) {
          this.productForm.addControl(
            'lengthInCm',
            this.fb.control(
              this.data.product?.lengthInCm || null,
              Validators.min(1),
            ),
          );
        }
        break;

      case 'Bouquet':
        if (!this.productForm.contains('occasion')) {
          this.productForm.addControl(
            'occasion',
            this.fb.control(
              this.data.product?.occasion || '',
              Validators.required,
            ),
          );
        }
        if (!this.productForm.contains('typeOfArrangement')) {
          this.productForm.addControl(
            'typeOfArrangement',
            this.fb.control(
              this.data.product?.typeOfArrangement || '',
              Validators.required,
            ),
          );
        }
        if (!this.productForm.contains('decorationWay')) {
          this.productForm.addControl(
            'decorationWay',
            this.fb.control(
              this.data.product?.decorationWay || '',
              Validators.required,
            ),
          );
        }
        break;
    }
  }

  private removeTypeSpecificControls() {
    this.productForm.removeControl('role');
    this.productForm.removeControl('flowerType');
    this.productForm.removeControl('color');
    this.productForm.removeControl('lengthInCm');
    this.productForm.removeControl('occasion');
    this.productForm.removeControl('typeOfArrangement');
    this.productForm.removeControl('decorationWay');
  }

  private detectProductType(product: any): ProductType {
    if (product.role !== undefined && product.role !== null)
      return 'Decoration';
    if (product.flowerType !== undefined && product.flowerType !== null)
      return 'Flower';
    if (product.occasion !== undefined && product.occasion !== null)
      return 'Bouquet';

    const category = product.category?.toLowerCase() || '';
    if (category.includes('flower')) return 'Flower';
    if (category.includes('bouquet')) return 'Bouquet';

    return 'Decoration';
  }

  onSubmit() {
    if (this.productForm.valid) {
      let product = this.productForm.value;

      if (!product.imageThumbnailUrl) {
        product.imageThumbnailUrl = product.imageUrl;
      }

      if (this.data.product) {
        product.id = this.data.product.id;
      }

      this.dialogRef.close({
        product,
        productType: this.selectedProductType,
      });
    }
  }
}
