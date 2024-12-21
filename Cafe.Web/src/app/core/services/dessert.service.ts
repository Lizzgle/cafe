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
}
