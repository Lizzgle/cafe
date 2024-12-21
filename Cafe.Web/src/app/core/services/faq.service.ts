import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';  // Импортируем Observable из rxjs

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FaqService {
private apiUrl = 'http://localhost:5079/api/faqs';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  // Получение всех напитков
  getFaqs(): Observable<[]> {
    return this.http.get<[]>(this.apiUrl);
  }
}
