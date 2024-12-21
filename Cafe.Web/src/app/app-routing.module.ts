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


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'account', component:  AccountComponent},
  { path: 'menu', component: MenuComponent},
  { path: 'faq', component: FaqComponent},
  { path: 'feedbacks', component: FeedbackComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
