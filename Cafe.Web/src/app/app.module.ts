import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MainBannerComponent } from './pages/home/main-banner/main-banner.component';
import { AboutUsComponent } from './pages/home/about-us/about-us.component';
import { MenuComponent } from './pages/home/menu/menu.component';
import { FooterComponent } from './components/footer/footer';

@NgModule({
  declarations: [
    AppComponent,
    MainBannerComponent,
    AboutUsComponent,
    MenuComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
