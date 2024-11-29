using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Handlers;

internal class UpdateDessertCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDessertCommandRequest>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;

    public async Task Handle(UpdateDessertCommandRequest request, CancellationToken cancellationToken)
    {
        var dessert = await _dessertRepository.GetByIdAsync(request.Id, cancellationToken);

        if (dessert == null)
        {
            throw new NotFoundException(ExceptionMessages.DessertNotFound);
        }

        dessert.Name = request.Name;
        dessert.Description = request.Description;
        dessert.Price = request.Price;
        dessert.Calories = request.Calories;

        await _dessertRepository.UpdateAsync(dessert, cancellationToken);
    }
}
