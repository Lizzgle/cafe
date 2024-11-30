using AutoMapper;
using Cafe.Application.Common.DTOs.Drinks;
using Cafe.Application.Usecases.Drinks.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Queries.Handlers;

internal class GetDrinksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDrinksQueryRequest, List<DrinkDto>>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;
    private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;

    public async Task<List<DrinkDto>> Handle(GetDrinksQueryRequest request, CancellationToken cancellationToken)
    {
        var drinks = await _drinkRepository.GetAllAsync(cancellationToken);

        foreach (var drink in drinks)
        {
            var prices = await _priceRepository.GetPricesForDrink(drink.Id, cancellationToken);

            drink.Prices = prices;
        }

        return mapper.Map<List<DrinkDto>>(drinks);
    }
}
