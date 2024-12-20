using Cafe.Application.Usecases.Ingredients.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Handlers;

public class CreateIngredientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateIngredientCommandRequest>
{
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task Handle(CreateIngredientCommandRequest request, CancellationToken cancellationToken)
    {
        var ingredient = await _ingredientRepository.GetIngredientByName(request.Name);

        if (ingredient is not null)
        {
            throw new AlreadyExistsException(ExceptionMessages.IngredientAlredyExists);
        }

        ingredient = new Ingredient() { Name = request.Name };

        await _ingredientRepository.CreateAsync(ingredient, cancellationToken);
    }
}
