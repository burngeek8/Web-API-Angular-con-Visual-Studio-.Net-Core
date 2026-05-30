import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { LoginEmpleadoRequest, LoginEmpleadoResponse } from '../models/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  private readonly apiUrl =
    'https://siscom-chd6bkbjfugxdpam.westcentralus-01.azurewebsites.net/api/empleados';
  private readonly tokenKey = 'auth_token';

  login(request: LoginEmpleadoRequest) {
    return this.http
      .post<LoginEmpleadoResponse>(`${this.apiUrl}/login`, request)
      .pipe(
        tap((response) => {
          this.saveToken(response.token);
        })
      );
  }

  logout() {
    this.removeToken();
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  private saveToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  private removeToken() {
    localStorage.removeItem(this.tokenKey);
  }
}
