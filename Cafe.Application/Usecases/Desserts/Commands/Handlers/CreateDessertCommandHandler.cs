using AutoMapper;
using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Handlers;

public class CreateDessertCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDessertCommandRequest>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;
    readonly private IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task Handle(CreateDessertCommandRequest request, CancellationToken cancellationToken)
    {
        if(await _dessertRepository.GetDessertByName(request.Name, cancellationToken) is not null)
        {
            throw new AlreadyExistsException(ExceptionMessages.DessertAlreadyExists);
        }

        var dessert = mapper.Map<Dessert>(request);

        await _dessertRepository.CreateAsync(dessert, cancellationToken);

        dessert = await _dessertRepository.GetDessertByName(request.Name, cancellationToken);

        var listIngredients = new List<Ingredient>();

        foreach (var ingredientName in request.Ingredients)
        {
            var ingredient = await _ingredientRepository.GetIngredientByName(ingredientName);

            if (ingredient is null)
            {
                ingredient = new Ingredient() { Name = ingredientName };

                await _ingredientRepository.CreateAsync(ingredient);

                listIngredients.Add(ingredient);

                await _ingredientRepository.AddIngredientToDessert(dessert.Id, ingredient.Id, cancellationToken);

                continue;
            }

            listIngredients.Add(ingredient);

            await _ingredientRepository.AddIngredientToDessert(dessert.Id, ingredient.Id, cancellationToken);
        }

        dessert.Ingredients = listIngredients;

    }
}
