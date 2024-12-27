using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Drinks.Commands.Handlers
{
    public class AddIngredientToDrinkCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddIngredientToDrinkCommandRequest>
    {
        private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;
        public async Task Handle(AddIngredientToDrinkCommandRequest request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(request.Name);

            if (ingredient is null)
            {
                ingredient = new Ingredient() { Name = request.Name };

                await _ingredientRepository.CreateAsync(ingredient);

                await _ingredientRepository.AddIngredientToDrink(request.DrinkId, ingredient.Id, cancellationToken);

                return;
            }

            await _ingredientRepository.AddIngredientToDrink(request.DrinkId, ingredient.Id, cancellationToken);
        }
    }
}
