using AutoMapper;
using Cafe.Application.Common.DTOs.Drinks;
using Cafe.Application.Usecases.Drinks.Queries.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Queries.Handlers;

internal class GetDrinkByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDrinkByIdQueryRequest, DrinkDto>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;
    private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;

    public async Task<DrinkDto> Handle(GetDrinkByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var drink = await _drinkRepository.GetByIdAsync(request.Id);

        if (drink == null)
        {
            throw new NotFoundException(ExceptionMessages.DrinkNotFound);
        }

        var prices = await _priceRepository.GetPricesForDrink(drink.Id, cancellationToken);

        drink.Prices = prices;

        return mapper.Map<DrinkDto>(drink);
    }
}
