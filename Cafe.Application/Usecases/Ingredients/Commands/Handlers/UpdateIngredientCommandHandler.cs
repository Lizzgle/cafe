using Cafe.Application.Usecases.Ingredients.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Handlers;

internal class UpdateIngredientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateIngredientCommandRequest>
{
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task Handle(UpdateIngredientCommandRequest request, CancellationToken cancellationToken)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(request.Id, cancellationToken);

        if (ingredient == null)
        {
            throw new NotFoundException(ExceptionMessages.IngredientNotFound);
        }

        var existIngredient = await _ingredientRepository.GetIngredientByName(request.Name);

        if (existIngredient is not null)
        {
            throw new AlreadyExistsException(ExceptionMessages.IngredientAlredyExists);
        }

        ingredient.Name = request.Name;

        await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
    }
}
