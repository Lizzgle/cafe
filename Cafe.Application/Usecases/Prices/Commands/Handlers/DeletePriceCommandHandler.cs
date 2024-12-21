using AutoMapper;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Prices.Commands.Handlers;

public class DeletePriceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeletePriceCommandRequest>
{
    private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;

    public async Task Handle(DeletePriceCommandRequest request, CancellationToken cancellationToken)
    {
        var price = await _priceRepository.GetByIdAsync(request.Id, cancellationToken);

        if (price is null)
        {
            throw new NotFoundException(ExceptionMessages.PriceNotFound);                
        }

        await _priceRepository.DeleteAsync(price, cancellationToken);
    }
}
