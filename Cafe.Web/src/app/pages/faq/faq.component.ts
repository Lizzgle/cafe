import { Component, OnInit } from '@angular/core';

import { FaqService } from '../../core/services/faq.service';

import { Faq } from '../../core/models/faq.model';


@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrl: './faq.component.css'
})
export class FaqComponent implements OnInit {
  faqs: Faq[] = []; // Массив для хранения FAQ
  
  isOpen: boolean[] = [];

  constructor(private faqService: FaqService) { }

  ngOnInit(): void {
    this.getFaqs(); // Загружаем данные при инициализации компонента
  }

  // Метод для получения FAQ
  getFaqs(): void {
    this.faqService.getFaqs().subscribe(data => {
      this.faqs = data; // Заполняем массив данными из сервиса
    });

    this.isOpen = new Array(this.faqs.length).fill(false);
  }
  expanded: boolean[] = [];

  toggleCollapse(index: number): void {
    // Меняем состояние для текущего аккордеона
    this.expanded[index] = !this.expanded[index];
  }
}