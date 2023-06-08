import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user';
import { Router } from '@angular/router';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();
  errorsAccount: string[] | null = null;

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string | null) {
    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.baseUrl + 'account', {headers}).pipe(
      map((user: any) => {
        if (user) {
          localStorage.setItem('token', user.data.token);
          this.currentUserSource.next(user.data);
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
        this.currentUserSource.next(user.data);
      })
    )
  }

  register(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', values).pipe(
      tap((res:any) => {
        if (!res.error)
        {
          localStorage.setItem('token', res.data.token);
          this.currentUserSource.next(res.data);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get<boolean>(this.baseUrl + 'account/emailExists?EmailToCheck=' + email);
  }
}