import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


interface Desserts {
    id: string;
    name: string;
    description: string;
    price: number;
    calories: number;
    ingredients: string[];
}

@Injectable({
  providedIn: 'root',
})

export class DessertService {  // Базовый URL для API
  private apiUrl = 'http://localhost:5079/api/desserts';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  getDesserts(): Observable<Desserts[]> {
    return this.http.get<Desserts[]>(this.apiUrl);
  }

  deleteDessert(id: string): Observable<any> {
    return this.http.delete<[]>(`${this.apiUrl}/${id}`);
  }

  getDessertsById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createDessert(dessert: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, dessert);
  }

  updateDessert(dessert: Desserts): Observable<Desserts> {
    console.log(dessert.id);
    return this.http.put<Desserts>(`${this.apiUrl}/${dessert.id}`, dessert);
  }

  addIngredient(dessert: any): Observable<any> {
    return this.http.patch(`${this.apiUrl}/${dessert.Id})`, dessert.ingredients)
  }

  removeIngredient(dessert: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${dessert.Id})`, dessert.ingredients)
  }
}
