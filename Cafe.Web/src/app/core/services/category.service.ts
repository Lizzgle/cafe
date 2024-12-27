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

export class CategoryService {  // Базовый URL для API
  private apiUrl = 'http://localhost:5079/api/Categories';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

}
