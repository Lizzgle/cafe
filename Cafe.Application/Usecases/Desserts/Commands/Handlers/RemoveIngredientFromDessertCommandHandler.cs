using Cafe.Application.Usecases.Desserts.Commands.Requests;
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
    internal class RemoveIngredientFromDessertCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveIngredientFromDessertCommandRequest>
    {
        private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;
        public async Task Handle(RemoveIngredientFromDessertCommandRequest request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(request.Name);

            if (ingredient is null)
            {
                return;
            }

            await _ingredientRepository.RemoveIngredientFromDessert(request.DessertId, ingredient.Id, cancellationToken);
        }
    }
}
