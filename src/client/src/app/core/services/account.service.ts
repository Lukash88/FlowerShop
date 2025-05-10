import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { ReplaySubject, of, tap, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Address, User } from 'src/app/shared/models/user';
import { IValidationResponse } from 'src/app/shared/models/validationResponse';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  currentUser = signal<User | null>(null);
  errorsAccount: string[] | null = null;

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string | null) {
    if (token === null) {
      this.currentUser.set(null);
      return of(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${ token }`);

    return this.http.get<User>(this.baseUrl + 'account', { headers }).pipe(
      map((user: any) => {
        user = user.data;
        if (user) {          
          localStorage.setItem('token', user.token);
          this.currentUser.set(user);
          return user;
        } else {
          return null;
        }
      })
    );
  }

  login(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', values).pipe(
      map((user: any) => {
        localStorage.setItem('token', user.data.token);
        this.currentUser.set(user.data);
      })
    );
  }

  register(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', values).pipe(
      tap((res: any) => {
        if (!res.error) {
          localStorage.setItem('token', res.data.token);
          this.currentUser.set(res.data);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser.set(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get<IValidationResponse>(
      this.baseUrl + 'account/emailExists?EmailToCheck=' + email
    );
  }

  getUserAddress() {
    return this.http.get<Address>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: Address) {
    return this.http.put(this.baseUrl + 'account/address', address);
  }
}