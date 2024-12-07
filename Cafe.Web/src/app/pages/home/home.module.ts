import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { MainBannerComponent } from './main-banner/main-banner.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
    declarations: [
        HomeComponent,
        MainBannerComponent,
        AboutUsComponent,
        MenuComponent,
    ],
    imports: [ CommonModule ],
    exports: [
        HomeComponent,
        MainBannerComponent,
        AboutUsComponent,
        MenuComponent,
      ],
    providers: [],
})
export class HomeModule {}