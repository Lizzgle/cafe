import { Component, OnInit } from '@angular/core';
import { DrinkService } from '../../../core/services/drink.service'; // Импортируем сервис

import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

interface Price {
  id: string;
  sizeName: string;
  cost: number;
}

interface DrinkWithPrices {
  id: string;
  name: string;
  description: string;
  categoryName: string;
  prices: Price[];
  ingredients: string[];
}

@Component({
  selector: 'app-drinks',
  templateUrl: './drinks.component.html',
  styleUrls: ['./drinks.component.css']
})


export class DrinksComponent implements OnInit {
  
  drinks: DrinkWithPrices[] = []; // Переменная для хранения списка напитков

  constructor(private drinkService: DrinkService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getDrinks();
  }

  // Метод для получения данных
  getDrinks(): void {
    this.drinkService.getDrinks().subscribe(data => {
      this.drinks = data; // Сохраняем данные в переменную
    });
  }

  openDrink(drinkId: string) {
    this.router.navigate(['menu/drink', drinkId]);
  }

  deleteDrink(drinkId: string) {
    this.drinkService.deleteDrink(drinkId).subscribe(
      () => this.getDrinks()
    );
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }
}
