import { Component } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})



export class LoginComponent {
  formData = {
    login: '',
    password: ''
  }
  errorMessage: string = '';  // Сообщение об ошибке

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.login(this.formData).subscribe(
      (response) => {
        // Если регистрация успешна, можно что-то сделать, например, перенаправить
        console.log('Login successful', response);
        this.authService.saveTokens(response.jwtToken, response.refreshToken);
        this.router.navigate(['/account']);
      },
      (error) => {
        // В случае ошибки, сохраняем ошибку в переменную и показываем сообщение
        this.errorMessage = error.message;
      }
    );
  }
  
}



