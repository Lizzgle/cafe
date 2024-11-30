using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Handlers;

internal class UpdateDrinkCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDrinkCommandRequest>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;

    public async Task Handle(UpdateDrinkCommandRequest request, CancellationToken cancellationToken)
    {
        var drink = await _drinkRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drink == null)
        {
            throw new NotFoundException(ExceptionMessages.DessertNotFound);
        }

        drink.Name = request.Name;
        drink.Description = request.Description;

        await _drinkRepository.UpdateAsync(drink, cancellationToken);
    }
}
