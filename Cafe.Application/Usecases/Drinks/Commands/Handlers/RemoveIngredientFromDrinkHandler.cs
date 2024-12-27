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
    public class RemoveIngredientFromDrinkHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveIngredientFromDrinkRequest>
    {
        private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;
        public async Task Handle(RemoveIngredientFromDrinkRequest request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(request.Name);

            if (ingredient is null)
            {
                return;
            }

            await _ingredientRepository.RemoveIngredientFroDrink(request.DrinkId, ingredient.Id, cancellationToken);
        }
    }
}
