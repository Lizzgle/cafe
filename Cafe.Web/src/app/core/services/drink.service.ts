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
  ingredients: string[];
}

@Injectable({
  providedIn: 'root',
})

export class DrinkService {
  private apiUrl = 'http://localhost:5079/api/drinks';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  // Получение всех напитков
  getDrinks(): Observable<DrinkWithPrices[]> {
    return this.http.get<DrinkWithPrices[]>(this.apiUrl);
  }
}
