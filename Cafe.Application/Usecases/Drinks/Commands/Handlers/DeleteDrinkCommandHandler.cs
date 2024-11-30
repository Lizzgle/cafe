using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Handlers;

internal class DeleteDrinkCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDrinkCommandRequest>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;

    public async Task Handle(DeleteDrinkCommandRequest request, CancellationToken cancellationToken)
    {
        var drink = await _drinkRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drink == null)
        {
            throw new NotFoundException(ExceptionMessages.DrinkNotFound);
        }

        await _drinkRepository.DeleteAsync(drink, cancellationToken);
    }
}
