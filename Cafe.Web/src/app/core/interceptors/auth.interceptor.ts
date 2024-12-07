import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { catchError, switchMap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // 1. Извлекаем JWT токен из cookies
    const jwtToken = this.authService.getJwtToken();
    
    // 2. Клонируем запрос и добавляем токен в заголовок, если он есть
    let clonedRequest = req;
    if (jwtToken) {
      clonedRequest = req.clone({
        setHeaders: {
          Authorization: `Bearer ${jwtToken}`
        }
      });
    }

    // 3. Отправляем запрос
    return next.handle(clonedRequest).pipe(
      catchError((error) => {
        // 4. Если ошибка 401 (неавторизован), пробуем обновить токен с помощью refresh токена
        if (error.status === 401) {
          return this.handleAuthError(req, next);
        }
        return throwError(() => error); // Перехватываем ошибку, если не 401
      })
    );
  }

  private handleAuthError(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Получаем refresh токен из localStorage
    const refreshToken = this.authService.getRefreshToken();

    if (refreshToken) {
      // Если refresh токен существует, пробуем обновить JWT токен
      return this.authService.refreshJwtToken(refreshToken).pipe(
        switchMap((tokens) => {
          // Если обновление прошло успешно, сохраняем новый JWT токен и отправляем запрос заново
          this.authService.saveTokens(tokens.jwtToken, tokens.refreshToken);

          // Клонируем запрос с новым JWT токеном и отправляем его
          const clonedRequest = req.clone({
            setHeaders: {
              Authorization: `Bearer ${tokens.jwtToken}`
            }
          });

          return next.handle(clonedRequest);
        }),
        catchError((refreshError) => {
          // Если не удалось обновить токен, удаляем все токены и перенаправляем на страницу логина
          this.authService.logout();
          this.router.navigate(['/login']);
          return throwError(() => refreshError);
        })
      );
    } else {
      // Если нет refresh токена, перенаправляем на страницу логина
      this.authService.logout();
      this.router.navigate(['/login']);
      return throwError(() => new Error('No refresh token available'));
    }
  }
}
