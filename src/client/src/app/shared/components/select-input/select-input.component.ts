import { Component, EventEmitter, Input, Output, Self } from '@angular/core';
import {
  ControlValueAccessor,
  NgControl,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-select-input',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, ReactiveFormsModule],
  templateUrl: './select-input.component.html',
  styleUrl: './select-input.component.scss',
})
export class SelectInputComponent implements ControlValueAccessor {
  @Input() label = '';
  @Input() options: string[] = [];
  @Output() selectionChange = new EventEmitter<any>();

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }

  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}

  onSelectionChange(event: any) {
    this.selectionChange.emit(event);
  }

  get formControl(): FormControl {
    return this.controlDir.control as FormControl;
  }
}
