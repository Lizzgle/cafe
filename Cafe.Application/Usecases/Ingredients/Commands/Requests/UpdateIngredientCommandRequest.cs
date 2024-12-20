using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Requests;

public class UpdateIngredientCommandRequest : IRequest
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
}
