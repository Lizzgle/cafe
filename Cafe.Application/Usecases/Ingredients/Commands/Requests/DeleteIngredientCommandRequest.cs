using MediatR;

namespace Cafe.Application.Usecases.Ingredients.Commands.Requests;

public class DeleteIngredientCommandRequest : IRequest
{
    public required Guid Id { get; set; }
}
