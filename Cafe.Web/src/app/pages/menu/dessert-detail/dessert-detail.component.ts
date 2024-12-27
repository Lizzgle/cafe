import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';

import { DessertService } from '../../../core/services/dessert.service'; // Импортируем сервис для работы с десертами

@Component({
  selector: 'app-dessert-detail',
  templateUrl: './dessert-detail.component.html',
  styleUrl: './dessert-detail.component.css'
})
export class DessertDetailComponent implements OnInit {;
  dessert = {
    id: '',
    name: '',
    description: '',
    calories: 0,
    price: 0,
    ingredients: [] as string[],
  };

  constructor(
    private route: ActivatedRoute,
    private dessertService: DessertService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.dessertService.getDessertsById(id).subscribe(
        (data) => (this.dessert = data),
        (error) => console.error('Error loading dessert:', error)
      );
    }
  }

  saveChanges() {
    console.log(this.dessert);
    this.dessertService.updateDessert(this.dessert).subscribe(
      () => this.router.navigate(['/menu']),
      (error) => console.error('Error saving dessert:', error)
    );
  }

  addIngredient() {
    this.dessertService.addIngredient(this.dessert);
  }

  removeIngredient(index: number) {
    if (this.dessert.ingredients) {
      this.dessertService.removeIngredient(index);
    }
  }
}