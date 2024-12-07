import { Component } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})

export class SignUpComponent {
  formData = {
    login: '',
    name: '',
    password: '',
    dateOfBirth: ''
  };
  errorMessage: string = '';

  constructor(private authService: AuthService) { }

  onSubmit() {
    this.authService.register(this.formData).subscribe(
      (response) => {
        // Если регистрация успешна, можно что-то сделать, например, перенаправить
        console.log('Registration successful', response);
        this.authService.saveTokens(response.jwtToken, response.refreshToken);
      },
      (error) => {
        // В случае ошибки, сохраняем ошибку в переменную и показываем сообщение
        this.errorMessage = error.message;
      }
    );
  }
}
