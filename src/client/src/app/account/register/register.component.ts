import { Component, OnInit, inject } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, 
  FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { GenderEnum } from 'src/app/shared/models/gender';
import { catchError, debounceTime, finalize, 
  map, switchMap, take, of } from 'rxjs';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss'],
    standalone: false
})
export class RegisterComponent implements OnInit {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  registerForm: FormGroup = new FormGroup({});
  complexPassword =
    "(?=^.{8,20}$)(?=.*d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*s).*$";
  errors: string[] | null = [];
  email: string;

  genders = [
    { value: GenderEnum.None, text: 'Prefer not to say' },
    { value: GenderEnum.Male, text: 'Male' },
    { value: GenderEnum.Female, text: 'Female' },
    { value: GenderEnum.Other, text: 'Others' },
  ];


  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      displayName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50), Validators.email],
        [this.validateEmailNotTaken()]],
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [ Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      password: [ '', [ Validators.required, Validators.minLength(8), Validators.maxLength(20),
          Validators.pattern(this.complexPassword)]],
      dateOfBirth: [null],
      gender: [null],
      street: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      postalCode: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      city: [ '', [ Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      confirmPassword: ['',  [Validators.required, this.matchValues('password')]]
    });

    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () =>
        this.registerForm.controls['confirmPassword'].updateValueAndValidity(),
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value
        ? null : { notMatching: true };
    };
  }

  passwordMatchValidator(group: AbstractControl) {
    return group.get('password').value === group.get('confirmPassword').value
      ? null : { mismatch: true };
  }

  onSubmit() {
    if (!this.registerForm.valid) return;

    this.accountService
      .register(this.registerForm.value)
      .pipe(catchError((response: any) => (this.errors = response.error)))
      .subscribe(() =>
        this.router.navigateByUrl('/shop')
      );
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        debounceTime(1000),
        take(1),
        switchMap(() => {
          this.email = control.value;
          return this.accountService.checkEmailExists(this.email).pipe(
            catchError((response: any) => {
              {
                this.errors.push(response.error);
                return of([]);
              }
            }),
            map((result: any) =>
              !(result.data === false) ? { emailExists: true } : null
            ),
            finalize(() => control.markAsTouched())
          );
        })
      );
    };
  }

  cancel() {
    //this.cancelRegister.emit(false);
    this.router.navigateByUrl('/shop');
  }

  private getDateOnly(dob: string | undefined) {
    if (!dob) return;
    let theDob = new Date(dob);
    return new Date(
      theDob.setMinutes(theDob.getMinutes() - theDob.getTimezoneOffset())
    )
      .toISOString()
      .slice(0, 10);
  }
}