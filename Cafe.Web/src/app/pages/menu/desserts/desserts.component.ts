import { Component, OnInit } from '@angular/core';

import { DessertService } from '../../../core/services/dessert.service'; // Импортируем сервис
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

interface Dessert {
  id: string;
  name: string;
  description: string;
  price: number;
  calories: number;
  ingredients: string[];
}

@Component({
  selector: 'app-desserts',
  templateUrl: './desserts.component.html',
  styleUrl: './desserts.component.css'
})

export class DessertsComponent implements OnInit {
  desserts: Dessert[] = []; // Переменная для хранения списка десертов

  newDessert = {
    name: '',
    description: '',
    calories: 0,
    price: 0,
    ingredients: [] as string[],
  };

  ingredientInput: string = '';

  constructor(private dessertService: DessertService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getDesserts();
  }

  // Метод для получения данных
  getDesserts(): void {
    this.dessertService.getDesserts().subscribe(data => {
      this.desserts = data; // Сохраняем данные в переменную
    });
  }

  openDessert(dessertId: string) {
    this.router.navigate(['menu/dessert', dessertId]);
  }

  deleteDessert(dessertId: string) {
    this.dessertService.deleteDessert(dessertId).subscribe(
      () => this.getDesserts()
    );
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  updateIngredients() {
    console.log(this.ingredientInput)
    // Разбиваем строку на элементы списка по запятой и очищаем от лишних пробелов
    this.newDessert.ingredients = this.ingredientInput
      .split(',')
      .map(ingredient => ingredient.trim())  // Очищаем пробелы вокруг каждого ингредиента
      .filter(ingredient => ingredient); // Убираем пустые строки

      console.log("после", this.newDessert.ingredients);
    this.ingredientInput = ''; // Очищаем поле ввода после обработки
  }

  createDessert() {
    console.log(this.newDessert.ingredients);
    this.dessertService.createDessert(this.newDessert).subscribe({
      next: (response) => {
        console.log('Dessert created:', response);
        alert('Dessert created successfully!');
        this.resetForm();
      },
      error: (err) => {
        console.error('Error creating dessert:', err);
        alert('Failed to create dessert.');
      }
    });
  }

  resetForm() {
    this.newDessert = {
      name: '',
      description: '',
      calories: 0,
      price: 0,
      ingredients: ['']
    };
  }

  
}