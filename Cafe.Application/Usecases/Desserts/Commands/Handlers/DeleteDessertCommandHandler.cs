using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Handlers;

internal class DeleteDessertCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDessertCommandRequest>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;

    public async Task Handle(DeleteDessertCommandRequest request, CancellationToken cancellationToken)
    {
        var dessert = await _dessertRepository.GetByIdAsync(request.Id, cancellationToken);

        if (dessert == null)
        {
            throw new NotFoundException(ExceptionMessages.DessertNotFound);
        }

        await _dessertRepository.DeleteAsync(dessert, cancellationToken);
    }
}
