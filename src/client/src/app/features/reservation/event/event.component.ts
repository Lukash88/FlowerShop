import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ReactiveFormsModule, FormGroup } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { DatePickerComponent } from 'src/app/shared/components/date-picker/date-picker.component';

@Component({
  selector: 'app-event',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    DatePickerComponent,
  ],
  templateUrl: './event.component.html',
})
export class EventComponent {
  @Input() eventForm!: FormGroup;
  @Input() today = new Date();
  @Output() next = new EventEmitter<void>();
  @Output() back = new EventEmitter<void>();

  onNext() {
    this.eventForm.markAllAsTouched();
    if (this.eventForm.valid) this.next.emit();
  }
}
