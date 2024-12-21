import { Component } from '@angular/core';

import { FeedbackService } from '../../core/services/feedback.service';

import { AuthService } from '../../core/services/auth.service';
import { Feedback } from '../../core/models/feedback.model';


@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrl: './feedback.component.css'
})
export class FeedbackComponent {
  reviews: any[] = [];  // Список отзывов
  newReview: Feedback = { 
    rating: 0,
    description: '' 
  };  // Новый отзыв
  isLoggedIn = false;  // Статус авторизации

  constructor(
    private reviewService: FeedbackService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    // Получаем отзывы из API
    this.reviewService.getFeedbacks().subscribe(
      (data) => {
        this.reviews = data;
      },
      (error) => {
        console.error('Ошибка при получении отзывов:', error);
      }
    );

    // Проверяем, авторизован ли пользователь
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  // Метод для отправки отзыва
  submitReview(): void {
    if (this.newReview.description.trim()) {
      const newReview = {
        rating: this.newReview.rating,
        description: this.newReview.description
      };

      // Отправляем новый отзыв на сервер
      this.reviewService.createFeedback(newReview).subscribe(() => {
          // Добавляем новый отзыв в список
        this.newReview.rating = 0;  // Очищаем поле ввода
        this.newReview.description = '';  // Очищаем поле ввода
      });
    }
  }

  currentPage = 1;
  itemsPerPage = 3;

  get paginatedReviews() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    return this.reviews.slice(startIndex, startIndex + this.itemsPerPage);
  }

  totalPages() {
    return Math.ceil(this.reviews.length / this.itemsPerPage);
  }

  changePage(page: number) {
    this.currentPage = page;
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  deleteReview(reviewId: string) {
    console.log(reviewId);
    // Удаляем отзыв из API
    this.reviewService.deleteFeedback(reviewId).subscribe(() => {
      // Удаляем отзыв из списка
      this.reviews = this.reviews.filter((review) => review.id!== reviewId);
    });
  }

  getStars(rating: number): number[] {
    return Array(Math.floor(rating)).fill(0); // Заполненные звёзды
  }
  
  getEmptyStars(rating: number): number[] {
    return Array(5 - Math.floor(rating)).fill(0); // Пустые звёзды
  }
}
