import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuComponent } from './menu.component';
import { DrinksComponent } from './drinks/drinks.component';
import { DessertsComponent } from './desserts/desserts.component';



@NgModule({
  declarations: [
    MenuComponent,
    DrinksComponent,
    DessertsComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MenuComponent,
    DrinksComponent,
    DessertsComponent
  ]
})
export class MenuModule { }
