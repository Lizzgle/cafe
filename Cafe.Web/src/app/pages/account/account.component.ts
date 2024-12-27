import { Component } from '@angular/core';
import { UserService } from '../../core/services/user.service';
import { User } from '../../core/models/user.model';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})

export class AccountComponent {
  user: User = { 
    id: '',
    name: '',
    login: '',
    email: '',
    dateOfBirth: '',
  }

  isEditing = false;

  // editedUser: User = { ...this.user };

  constructor(private userService: UserService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.getMeUserById();
  }

  getMeUserById() {
    this.userService.getMeUserById().subscribe((user: User) => {
      this.user = user;
    });
  }

  toggleEdit() {
    this.isEditing = !this.isEditing;

    // Если выходим из режима редактирования, сохраняем изменения
    if (!this.isEditing) {
      this.saveChanges();
    }
  }

  saveChanges() {
    // Сохраняем изменения в основном объекте user
    this.user = { ...this.user };

    // // Например, здесь можно отправить обновлённые данные на сервер:
    this.userService.updateUser(this.user).subscribe();

    this.user = {...this.user }; 
    this.isEditing = false;
    // Сбрасываем форму редактирования
  }

  cancelEdit() {
    if (this.user) {
      this.user = { ...this.user }; // Восстанавливаем данные
    }
    this.isEditing = false;
  }

  logout() {
    // Здесь нужно вызвать сервис авторизации и удалить токены
    this.authService.logout(); 
    this.router.navigate(['/login']); 
  }

  deleteUser(){
    // Здесь нужно вызвать сервис удаления пользователя и перенаправить на страницу авторизации
    this.userService.deleteUser(this.user.id).subscribe(() => {
      this.authService.logout();
      this.router.navigate(['/login']);
    });
  }
}
