import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { LoginRequest, LoginResponse } from "../models/auth";
import { tap } from "rxjs";


@Injectable({
     providedIn: 'root' 
})

export class AuthService {

    private http = inject(HttpClient);
    private router = inject(Router);

    private readonly apiUrl = 'http://localhost:7777/';
    private readonly tokenKey = 'auth_token';

    login(request : LoginRequest) {
        return this.http.post<LoginResponse>(`${this.apiUrl}api/usuario/login`, request).pipe(
            tap(response => {
                localStorage.setItem(this.tokenKey, response.token);
            })
        )
    }

    logout() {
        localStorage.removeItem(this.tokenKey);
        this.router.navigate(['/login']);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    isAuthenticated(): boolean {
        return !!this.getToken();
    }
}