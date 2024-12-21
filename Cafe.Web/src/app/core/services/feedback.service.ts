import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';  // Модуль RxJS для работы с потоками

import { HttpClient } from '@angular/common/http';
import { Feedback } from '../models/feedback.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
private apiUrl = 'http://localhost:5079/api/feedbacks';  // Базовый URL для API

  constructor(private http: HttpClient) {}

  // Получение всех напитков
  getFeedbacks(): Observable<[]> {
    return this.http.get<[]>(this.apiUrl);
  }

  createFeedback(feedback: Feedback): Observable<any> {
    return this.http.post(this.apiUrl, feedback);
  }

  deleteFeedback(feedbackId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${feedbackId}`);
  }

}
