using AutoMapper;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Cafe.Domain.Enums;
using Event.Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Prices.Commands.Handlers
{
    public class CreatePriceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<CreatePriceCommandRequest>
    {
        private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;

        public async Task Handle(CreatePriceCommandRequest request, CancellationToken cancellationToken)
        {
            var size = Size.FromString(request.SizeName);

            if (size is null)
            {
                throw new NotFoundException(ExceptionMessages.SizeNotFound);
            }

            if (await _priceRepository.GetPriceForDrinkAndSize(request.DrinkId, size.Id, cancellationToken) is not null)
            {
                throw new AlreadyExistsException(ExceptionMessages.PriceAlredyExists);
            }

            var price = mapper.Map<Price>(request);

            price.Size = (Size)price.SizeId;

            await _priceRepository.CreateAsync(price, cancellationToken);
        }
    }
}
