import { Component } from '@angular/core';

import { Observable } from 'rxjs';

import { DrinkService } from '../../../core/services/drink.service';
import { CategoryService } from '../../../core/services/category.service';

@Component({
  selector: 'app-create-drink',
  templateUrl: './create-drink.component.html',
  styleUrl: './create-drink.component.css'
})
export class CreateDrinkComponent {
  newDrink = {
    name: '',
    description: '',
    categoryName: '',
    prices: [] as { sizeName: string; cost: number }[],
    ingredients: [] as string[],
  };

  ingredientInput = ''; // Поле для ввода ингредиентов
  sizeName = ''; // Выбранный размер
  sizeCost: number | null = null; // Стоимость размера
  availableSizes = ['S', 'M', 'L']; // Предопределенные размеры
  availableCategories: any[] = [];

  constructor(private drinkService: DrinkService, private categoryService: CategoryService) {} // Используем сервис drinkService

  ngOnInit(): void {
    this.loadAvailableCategories(); // Загружаем категории при инициализации
  }
  
  // Загружаем категории с использованием сервиса
  loadAvailableCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.availableCategories = categories; // Присваиваем результат
      },
      error: (err) => {
        console.error('Ошибка при загрузке категорий:', err);
      }
    });
  }

  addPrice() {
    if (this.sizeName && this.sizeCost != null) {
      this.newDrink.prices.push({ sizeName: this.sizeName, cost: this.sizeCost });
      this.sizeName = '';
      this.sizeCost = null;
    } else {
      alert('Please select a size and enter a cost.');
    }
  }

  createDrink() {
    // Разбиваем ингредиенты из строки в массив
    if (this.ingredientInput) {
      this.newDrink.ingredients = this.ingredientInput
        .split(',')
        .map((ingredient) => ingredient.trim())
        .filter((ingredient) => ingredient); // Убираем пустые строки
    }

    console.log('Creating drink:', this.newDrink);
    this.drinkService.createDrink(this.newDrink).subscribe({
      next: (response) => {
        console.log('Dessert created:', response);
        this.resetForm();
      },
      error: (err) => {
        console.error('Error creating dessert:', err);
      }
    });
  }

  resetForm() {
    this.newDrink = {
      name: '',
      description: '',
      categoryName: '',
      prices: [] as { sizeName: string; cost: number }[],
      ingredients: [] as string[],
    };
  }
}
