import { Component, Input, inject } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-date-picker',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatButtonModule,
    NgIf
  ],
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss']
})
export class DatePickerComponent implements ControlValueAccessor {
  @Input() label = '';
  @Input() maxDate?: Date;

  ngControl = inject(NgControl);
  onChange = (value: any) => {};
  onTouched = () => {};

  constructor() {
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {
    const control = this.control;
    if (control && obj !== control.value) {
      control.setValue(obj, { emitEvent: false });
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;    
    this.ngControl.control?.valueChanges?.subscribe(value => {
      this.onChange(value);
    });
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  get control(): FormControl {
    return this.ngControl.control as FormControl;
  }
}