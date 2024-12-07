import { Component, OnInit } from '@angular/core';
import { MenuService} from '../../../core/services/menu.service';  // Импортируем сервис и типы

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
}

interface GroupedCategory {
  categoryName: string;
  drinks: DrinkWithPrices[];
}

interface Dessert {
  id: string;
  name: string;
  description: string;
  price: number;
  calories: number;
}

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})

export class MenuComponent implements OnInit {
  drinks: DrinkWithPrices[] = [];  // Все напитки
  desserts: Dessert[] = []; //
  groupedMenu: GroupedCategory[] = [];  // Группированные напитки
  loading: boolean = true; 
  error: string = '';

  constructor(private menuService: MenuService) {}

  ngOnInit() {
    this.loadDrinks();
    this.loadDesserts();  // Загружаем десерты
  }

  loadDrinks() {
    this.menuService.getDrinks().subscribe(data => {
      this.drinks = data;
      this.groupDrinksByCategory();  // Группируем напитки по категориям
      // this.loading = false;
    },
     
    );
  }

  loadDesserts() {
    this.menuService.getDesserts().subscribe(data => {
      this.desserts = data;
      this.loading = false;
    },
    );
  }

  // Группировка напитков по категориям
  groupDrinksByCategory() {
    const grouped = this.drinks.reduce((acc, drink) => {
      const category = acc.find(group => group.categoryName === drink.categoryName);
      if (category) {
        category.drinks.push(drink);
      } else {
        acc.push({ categoryName: drink.categoryName, drinks: [drink] });
      }
      return acc;
    }, [] as GroupedCategory[]);

    this.groupedMenu = grouped;
  }
}
