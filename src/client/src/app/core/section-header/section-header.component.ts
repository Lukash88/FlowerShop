import { Component, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'app-section-header',
    templateUrl: './section-header.component.html',
    styleUrls: ['./section-header.component.scss'],
    standalone: false
})
export class SectionHeaderComponent implements OnInit {
   private bcService = inject(BreadcrumbService);
  breadcrumb$: Observable<any[]>;

  constructor() { }

  ngOnInit(): void {
    this.breadcrumb$ = this.bcService.breadcrumbs$;
  }
}
