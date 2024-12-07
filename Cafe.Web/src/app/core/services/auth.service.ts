import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7111/api/auth'; 

  constructor(private http: HttpClient) {}

  register(userData: { login: string; name: string; password: string; dateOfBirth: string }): Observable<any> {
    return this.http.post(`${this.apiUrl}/registration`, userData).pipe(
      catchError((error) => {
        // Здесь можно обработать ошибку, например, вывести сообщение
        console.error('Registration error:', error);
        return throwError(() => new Error('Registration failed, please try again.'));
      })
    );
  }

  login(userData: { login: string; password: string}): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, userData).pipe(
      catchError((error) => {
        // Здесь можно обработать ошибку, например, вывести сообщение
        console.error('Login error:', error);
        return throwError(() => new Error('Login failed, please check your credentials.'));
      })
    );
  }

  saveTokens(jwtToken: string, refreshToken: string): void {
    
    localStorage.setItem('refreshToken', refreshToken);
    localStorage.setItem('jwtToken', jwtToken);
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  // Получение refresh token из cookies
  getJwtToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  // Удаление JWT токена
  logout(): void {
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('jwtToken');
  }

  refreshJwtToken(refreshToken: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/refresh-token`, { refreshToken }).pipe(
      catchError((error) => {
        console.error('Refresh token error:', error);
        return throwError(() => new Error('Failed to refresh token.'));
      })
    );
  }
}
