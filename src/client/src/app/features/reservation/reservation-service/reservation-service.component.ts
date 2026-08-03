import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ReactiveFormsModule, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { eventTypes } from 'src/app/shared/models/reservation';

@Component({
  selector: 'app-reservation-service',
  standalone: true,
  imports: [ReactiveFormsModule, MatButtonModule, MatIconModule],
  templateUrl: './reservation-service.component.html',
})
export class ReservationServiceComponent {
  @Input() serviceForm!: FormGroup;
  @Output() next = new EventEmitter<void>();

  eventTypes = eventTypes;

  getEventTypeIcon(type: string): string {
    const icons: Record<string, string> = {
      Wedding: 'favorite',
      Birthday: 'cake',
      Funeral: 'local_florist',
      Corporate: 'business',
      Anniversary: 'celebration',
      Other: 'event',
    };
    return icons[type] ?? 'event';
  }

  onNext() {
    this.serviceForm.get('eventType')?.markAsTouched();
    if (this.serviceForm.valid) this.next.emit();
  }
}
