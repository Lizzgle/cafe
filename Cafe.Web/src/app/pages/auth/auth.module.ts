import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Импортируйте FormsModule
import { SignUpComponent } from './sign-up/sign-up.component'; // Ваш компонент
import { LoginComponent } from './login/login.component'; //

@NgModule({
  declarations: [
    SignUpComponent, // Зарегистрируйте компонент
    LoginComponent //
  ],
  imports: [
    CommonModule,
    FormsModule // Добавьте FormsModule
  ]
})
export class AuthModule {}
