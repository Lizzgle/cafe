import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Определение интерфейсов для типизации данных
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

interface Desserts {
    id: string;
    name: string;
    description: string;
    price: number;
    calories: number;
}

@Injectable({
  providedIn: 'root',
})

export class MenuService {
  private apiUrlForDrinks = 'https://localhost:7111/api/drinks';  // Базовый URL для API
  private apiUrlForDesserts = 'https://localhost:7111/api/desserts';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  // Получение всех напитков
  getDrinks(): Observable<DrinkWithPrices[]> {
    return this.http.get<DrinkWithPrices[]>(this.apiUrlForDrinks);
  }

  getDesserts(): Observable<Desserts[]> {
    return this.http.get<Desserts[]>(this.apiUrlForDesserts);
  }
}
