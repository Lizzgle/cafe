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

  createDrink(drink: any): Observable<any> {
    return this.http.post(this.apiUrl, drink);
  }

  deleteDrink(drinkId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${drinkId}`);
  }

  updateDrink(drink: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${drink.id}`, drink);
  }

  getDrinkById(drinkId: string): Observable<DrinkWithPrices> {
    return this.http.get<DrinkWithPrices>(`${this.apiUrl}/${drinkId}`);
  }

  addIngredient(drink: any): Observable<any> {
    return this.http.patch(`${this.apiUrl}/${drink.Id})`, drink.ingredients)
  }

  removeIngredient(drink: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${drink.Id})`, drink.ingredients)
  }
}
