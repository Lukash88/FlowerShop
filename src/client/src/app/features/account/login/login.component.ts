import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/core/services/account.service';
import { TextInputComponent } from 'src/app/shared/components/text-input/text-input.component';

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [
      TextInputComponent,
      ReactiveFormsModule,
      MatCard,
      MatButton
    ],
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  private activatedRoute = inject(ActivatedRoute);
  returnUrl = '/shop';
  validationErrors?: string[] | null = null;

  constructor() {
    const url = this.activatedRoute.snapshot.queryParams['returnUrl'];
    if (url) this.returnUrl = url;
  }

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUserInfo().subscribe();
        this.router.navigateByUrl(this.returnUrl);
      },
      error: errors =>{ 
        if (errors.status === 401) {
          this.validationErrors = ['Invalid email or password.'];
        } else if (Array.isArray(errors.error)) {
          this.validationErrors = errors.error;        
        } 
      }
    });
  }
}
