import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer';
import { AuthModule } from './pages/auth/auth.module';
import { HomeModule } from './pages/home/home.module';
import { MenuModule } from './pages/menu/menu.module';

import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { AccountComponent } from './pages/account/account.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FaqComponent } from './pages/faq/faq.component';
import { FeedbackComponent } from './pages/feedback/feedback.component';
import { UsersListComponent } from './pages/user/list-users/list-users.component';
import { UserDetailComponent } from './pages/user/user-detail/user-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    AccountComponent,
    NavbarComponent,
    FaqComponent,
    FeedbackComponent,
    UsersListComponent,
    UserDetailComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule, 
    HttpClientModule,
    FormsModule,
    AuthModule,
    HomeModule,
    // MenuModule  // Add HomeModule to import the HomeComponent and its children
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true // Указывает, что можно зарегистрировать несколько интерсепторов
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
