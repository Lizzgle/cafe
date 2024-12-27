import { Component } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';

import { DrinkService } from '../../../core/services/drink.service';

@Component({
  selector: 'app-drink-detail',
  templateUrl: './drink-detail.component.html',
  styleUrl: './drink-detail.component.css'
})
export class DrinkDetailComponent {
  drink = {
    id: '',
    name: '',
    price: [],
    ingredients: [''],
    description: ''
  };

  ingredientInput = '';

  constructor(
    private drinkService: DrinkService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  saveChanges() {
    console.log(this.drink);
    this.drinkService.updateDrink(this.drink).subscribe(
      () => this.router.navigate(['/menu']),
      error => console.error('Error saving drink:', error)
    );
  }

  addIngredient() {
    if (this.ingredientInput) {
      this.drink.ingredients = this.ingredientInput
        .split(',')
        .map((ingredient) => ingredient.trim())
        .filter((ingredient) => ingredient); // Убираем пустые строки
    }
    this.drinkService.addIngredient(this.drink);
  }

  removeIngredient(index: number) {
    if (this.drink.ingredients) {
      this.drink.ingredients.splice(index, 1);
      this.drinkService.removeIngredient(this.drink);
    }
  }
}
