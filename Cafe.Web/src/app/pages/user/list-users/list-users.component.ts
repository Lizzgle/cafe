import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../../core/services/user.service';

import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrl: './list-users.component.css'
})
export class UsersListComponent implements OnInit {
  users: any[] = [];

  constructor(private userService: UserService, private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    // Получаем список пользователей из сервиса
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    });
  }

  goToUserDetail(userId: string): void {
    this.router.navigate(['/user', userId]);  // Переход на страницу конкретного пользователя
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  get isModerator(): boolean {
    return this.authService.isModerator();
  }

  deleteUser(userId: string) {
    console.log(userId);
    // Удаляем отзыв из API
    this.userService.deleteUser(userId).subscribe(() => {
      // Удаляем отзыв из списка
      this.users = this.users.filter((user) => user.id!== userId);
    });
  }

}