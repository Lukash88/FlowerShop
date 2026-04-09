import { Directive, effect, inject, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from 'src/app/core/services/account.service';

@Directive({
  selector: '[appIsAdmin]',
  standalone: true
})
export class IsAdminDirective {
  private accountService = inject(AccountService);
  private viewContainer = inject(ViewContainerRef);
  private templateRef = inject(TemplateRef);

  constructor() {
    effect(() => {
      if (this.accountService.isAdmin()) {
        this.viewContainer.createEmbeddedView(this.templateRef);
      } else {
        this.viewContainer.clear();
      }
    });
  }
}
