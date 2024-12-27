using AutoMapper;
using Cafe.Application.Common.DTOs.Drinks;
using Cafe.Application.Usecases.Drinks.Queries.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Models;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Queries.Handlers;

internal class GetDrinksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDrinksQueryRequest, List<DrinkDto>>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;
    private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task<List<DrinkDto>> Handle(GetDrinksQueryRequest request, CancellationToken cancellationToken)
    {
        var drinks = await _drinkRepository.GetAllAsync(cancellationToken);

        foreach (var drink in drinks)
        {
            var prices = await _priceRepository.GetPricesForDrink(drink.Id, cancellationToken);

            var ingredients = await _ingredientRepository.GetIngredientForDrink(drink.Id, cancellationToken);

            drink.Prices = prices;
            drink.Ingredients = ingredients;
        }

        //var drinks = _drinkRepository.GetDrinkDetails();

        return mapper.Map<List<DrinkDto>>(drinks);
    }
}
