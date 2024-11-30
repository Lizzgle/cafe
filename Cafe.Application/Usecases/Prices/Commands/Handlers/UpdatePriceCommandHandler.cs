using AutoMapper;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Prices.Commands.Handlers
{
    public class UpdatePriceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdatePriceCommandRequest>
    {
        private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;

        public async Task Handle(UpdatePriceCommandRequest request, CancellationToken cancellationToken)
        {
            var price = await _priceRepository.GetByIdAsync(request.Id, cancellationToken);

            if (price is null)
            {
                throw new NotFoundException(ExceptionMessages.PriceNotFound);
            }

            price.Cost = request.Cost;

            await _priceRepository.UpdateAsync(price, cancellationToken);
        }
    }
}
