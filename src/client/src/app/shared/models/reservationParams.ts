export class ReservationParams {
  pageNumber = 1;
  pageSize = 10;
  sort = '-dateOfEvent';
  status?: string;
  eventType?: string;
}

export const SortOptions = [
    { name: 'Latest first', value: '-dateOfEvent' },
    { name: 'Earliest first', value: 'dateOfEvent' }
  ];
