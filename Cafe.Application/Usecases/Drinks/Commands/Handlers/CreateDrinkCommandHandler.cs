using AutoMapper;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Cafe.Domain.Enums;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Handlers;

internal class CreateDrinkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDrinkCommandRequest>
{
    private readonly IDrinkRepository _drinkRepository = unitOfWork.DrinkRepository;
    private readonly IPriceRepository _priceRepository = unitOfWork.PriceRepository;
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task Handle(CreateDrinkCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _drinkRepository.GetDrinkByName(request.Name, cancellationToken) is not null)
        {
            throw new AlreadyExistsException(ExceptionMessages.DrinkAlreadyExists);
        }

        var drink = mapper.Map<Drink>(request);

        var category = Category.FromString(request.CategoryName);

        if (category is null)
        {
            throw new NotFoundException(ExceptionMessages.CategoryNotFound);
        }

        drink.CategoryId = category.Id;
        drink.Category = category;

        await _drinkRepository.CreateAsync(drink, cancellationToken);

        var listIngredients = new List<Ingredient>();

        foreach (var ingredientName in request.Ingredients)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(ingredientName);

            if (ingredient is null)
            {
                ingredient = new Ingredient() { Name = ingredientName };

                await _ingredientRepository.CreateAsync(ingredient);

                listIngredients.Add(ingredient);

                await _ingredientRepository.AddIngredientToDrink(drink.Id, ingredient.Id, cancellationToken);

                continue;
            }

            listIngredients.Add(ingredient);

            await _ingredientRepository.AddIngredientToDrink(drink.Id, ingredient.Id, cancellationToken);
        }

        drink.Ingredients = listIngredients;


        var drinkId = drink.Id;

        foreach (var price in request.Prices)
        {
            var size = Size.FromString(price.SizeName);

            if (size is null)
            {
                throw new NotFoundException(ExceptionMessages.SizeNotFound);
            }

            var priceEntity = new Price
            {
                DrinkId = drinkId,
                SizeId = size.Id,
                Size = size,
                Cost = price.Cost
            };

            await _priceRepository.CreateAsync(priceEntity, cancellationToken);
        }
    }
}
