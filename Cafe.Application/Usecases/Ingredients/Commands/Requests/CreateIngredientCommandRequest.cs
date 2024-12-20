using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Requests;

public class CreateIngredientCommandRequest : IRequest
{
    public required string Name { get; set; }
}
