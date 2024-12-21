import { Component } from '@angular/core';

import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isAuthenticated: boolean = false; // Замените на проверку авторизации из вашего сервиса
  

  constructor(private authService: AuthService) {
    this.isAuthenticated = this.authService.isLoggedIn(); // Проверка статуса
  }

  logout() {
    this.authService.logout(); // Реализация выхода
    this.isAuthenticated = false;
  }
}
