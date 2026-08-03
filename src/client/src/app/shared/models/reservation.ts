export type Reservation = {
  id: number;
  email: string;
  orderId?: number;
  eventType: string;
  dateOfEvent: string;
  reservedOn: string;
  reservationStatus: string;
  servicePrice?: number;
  eventDescription?: string;
  eventAddressLine1: string;
  eventAddressLine2?: string;
  eventCity: string;
  eventState: string;
  eventPostalCode: string;
  eventCountry: string;
}

export interface PendingReservation {
  eventType: string;
  dateOfEvent: string;
  eventStreet?: string;
  eventCity?: string;
  eventPostalCode?: string;
  eventDescription?: string;
  servicePrice?: number;
}

export type ReservationState =
  | 'Pending'
  | 'Processing'
  | 'Confirmed'
  | 'Cancelled'
  | 'Expired';

export const reservationStates: ReservationState[] = [
  'Pending',
  'Processing',
  'Confirmed',
  'Cancelled',
  'Expired',
];

export type EventType =
  | 'Birthday'
  | 'BabyShower'
  | 'Baptism'
  | 'BrandOfProductLaunch'
  | 'InternalCompanyMeeting'
  | 'Congratulations'
  | 'Anniversary'
  | 'Romantic'
  | 'JustBecause'
  | 'PrivateParty'
  | 'Engagement'
  | 'CivilWedding'
  | 'ChurchWedding'
  | 'WeddingParty'
  | 'NewHome'
  | 'ThankYou'
  | 'Halloween'
  | 'Funeral';

export const eventTypes: EventType[] = [
  'Birthday',
  'BabyShower',
  'Baptism',
  'BrandOfProductLaunch',
  'InternalCompanyMeeting',
  'Congratulations',
  'Anniversary',
  'Romantic',
  'JustBecause',
  'PrivateParty',
  'Engagement',
  'CivilWedding',
  'ChurchWedding',
  'WeddingParty',
  'NewHome',
  'ThankYou',
  'Halloween',
  'Funeral',
];

export const eventTypeLabels: Record<EventType, string> = {
  Birthday:               'Birthday',
  BabyShower:             'Baby Shower',
  Baptism:                'Baptism',
  BrandOfProductLaunch:   'Brand / Product Launch',
  InternalCompanyMeeting: 'Internal Company Meeting',
  Congratulations:        'Congratulations',
  Anniversary:            'Anniversary',
  Romantic:               'Romantic',
  JustBecause:            'Just Because',
  PrivateParty:           'Private Party',
  Engagement:             'Engagement',
  CivilWedding:           'Civil Wedding',
  ChurchWedding:          'Church Wedding',
  WeddingParty:           'Wedding Party',
  NewHome:                'New Home',
  ThankYou:               'Thank You',
  Halloween:              'Halloween',
  Funeral:                'Funeral',
};