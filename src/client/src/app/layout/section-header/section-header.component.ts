import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbComponent, BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'app-section-header',
    standalone: true,
    imports: [
      CommonModule,
      BreadcrumbComponent
    ],
    templateUrl: './section-header.component.html',
    styleUrls: ['./section-header.component.scss']    
})
export class SectionHeaderComponent implements OnInit {
   private bcService = inject(BreadcrumbService);
  breadcrumb$: Observable<any[]>;

  constructor() { }

  ngOnInit(): void {
    this.breadcrumb$ = this.bcService.breadcrumbs$;
  }
}
