using Cafe.Application.Usecases.Ingredients.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Handlers;

internal class DeleteIngredientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteIngredientCommandRequest>
{
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task Handle(DeleteIngredientCommandRequest request, CancellationToken cancellationToken)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(request.Id);

        if (ingredient == null)
        {
            throw new NotFoundException(ExceptionMessages.IngredientNotFound);
        }

        await _ingredientRepository.DeleteAsync(ingredient, cancellationToken);
    }
}
