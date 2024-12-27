import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppModule } from './app.module';
import { SignUpComponent } from './pages/auth/sign-up/sign-up.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { AppComponent } from './app.component';
import { HomeModule } from './pages/home/home.module';
import { HomeComponent } from './pages/home/home.component';
import { AccountComponent } from './pages/account/account.component';
import { MenuModule } from './pages/menu/menu.module';
import { MenuComponent } from './pages/menu/menu.component';
import { FaqComponent } from './pages/faq/faq.component';
import { FeedbackComponent } from './pages/feedback/feedback.component';

import { UserDetailComponent } from './pages/user/user-detail/user-detail.component';

import { UsersListComponent } from './pages/user/list-users/list-users.component';

import { DessertDetailComponent } from './pages/menu/dessert-detail/dessert-detail.component';

import { DrinkDetailComponent } from './pages/menu/drink-detail/drink-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'account', component:  AccountComponent},
  { path: 'menu', component: MenuComponent},
  { path: 'menu/dessert/:id', component: DessertDetailComponent },
  { path: 'menu/drink/:id', component: DrinkDetailComponent },
  { path: 'faq', component: FaqComponent},
  { path: 'feedbacks', component: FeedbackComponent},
  { path: 'users', component: UsersListComponent },
  { path: 'user/:id', component: UserDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
