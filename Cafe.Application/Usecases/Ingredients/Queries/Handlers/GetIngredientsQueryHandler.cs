using Cafe.Application.Usecases.Ingredients.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Queries.Handlers;

public class GetIngredientsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetIngredientsQueryRequest, List<string>>
{
    private readonly IIngredientRepository _ingredientRepository = unitOfWork.IngredientRepository;

    public async Task<List<string>> Handle(GetIngredientsQueryRequest request, CancellationToken cancellationToken)
    {
        var ingredients = await _ingredientRepository.GetAllAsync(cancellationToken);

        return ingredients.Select(x => x.Name).ToList();
    }
}
