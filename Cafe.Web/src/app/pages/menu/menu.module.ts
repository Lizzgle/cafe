import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MenuComponent } from './menu.component';
import { DrinksComponent } from './drinks/drinks.component';
import { DessertsComponent } from './desserts/desserts.component';
import { DessertDetailComponent } from './dessert-detail/dessert-detail.component';
import { CreateDrinkComponent } from './create-drink/create-drink.component';
import { DrinkDetailComponent } from './drink-detail/drink-detail.component';



@NgModule({
  declarations: [
    MenuComponent,
    DrinksComponent,
    DessertsComponent,
    DessertDetailComponent,
    CreateDrinkComponent,
    DrinkDetailComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    MenuComponent,
    DrinksComponent,
    DessertsComponent,
    DessertDetailComponent,
  ]
})
export class MenuModule { }
