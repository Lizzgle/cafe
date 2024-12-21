import { Component, OnInit } from '@angular/core';

import { DessertService } from '../../../core/services/dessert.service'; // Импортируем сервис

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

  constructor(private dessertService: DessertService) { }

  ngOnInit(): void {
    this.getDesserts();
  }

  // Метод для получения данных
  getDesserts(): void {
    this.dessertService.getDesserts().subscribe(data => {
      this.desserts = data; // Сохраняем данные в переменную
    });
  }
}