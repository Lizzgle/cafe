using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Desserts.Commands.Handlers
{
    internal class AddIngredientToDessertCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddIngredientToDessertCommandRequest>
    {
        private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;
        public async Task Handle(AddIngredientToDessertCommandRequest request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(request.Name);

            if (ingredient is null)
            {
                ingredient = new Ingredient() { Name = request.Name };

                await _ingredientRepository.CreateAsync(ingredient);

                await _ingredientRepository.AddIngredientToDessert(request.DessertId, ingredient.Id, cancellationToken);

                return;
            }

            await _ingredientRepository.AddIngredientToDessert(request.DessertId, ingredient.Id, cancellationToken);
        }
    }
}
