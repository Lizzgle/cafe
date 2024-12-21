using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Queries.Requests;

public class GetIngredientsQueryRequest : IRequest<List<string>>
{
}
