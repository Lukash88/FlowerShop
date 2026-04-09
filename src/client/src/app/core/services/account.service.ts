import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { tap, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Address, User } from 'src/app/shared/models/user';
import { IValidationResponse } from 'src/app/shared/models/validationResponse';
import { SignalrService } from './signalr.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  private router = inject(Router);
  private signalrService = inject(SignalrService);
  baseUrl = environment.apiUrl;
  currentUser = signal<User | null>(null);
  isAdmin = computed(() => {
    const roles = this.currentUser()?.roles;
    return Array.isArray(roles) ? roles.includes('Admin') : roles === 'Admin';
  });

  login(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', values).pipe(
      map((user: any) => {
        const token = user.data.token;
        localStorage.setItem('token', token);
        this.currentUser.set(user.data);
        this.signalrService.createHubConnection(token);
      })
    );
  }

  register(values: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', values).pipe(
      tap((res: any) => {
        if (!res.error) {
          this.currentUser.set(res.data);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser.set(null);
    this.router.navigateByUrl('/');
    this.signalrService.stopHubConnection();
  }

  checkEmailExists(email: string) {
    return this.http.get<IValidationResponse>(
      this.baseUrl + 'account/email-exists?EmailToCheck=' + email
    );
  }

  getUserAddress() {
    return this.http.get<Address>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: Address) {
    return this.http.put(this.baseUrl + 'account/address', address).pipe(
      tap(() => {
        this.currentUser.update(user => {
          if (user) {
            user.address = address;
          }
          return user;
        });
      })
    );
  }

  getUserInfo() {
    return this.http.get<User>(this.baseUrl + 'account/user-info').pipe(
      map((user: any) => {
        this.currentUser.set(user.data);
        return user;
      })
    )
  }
}
