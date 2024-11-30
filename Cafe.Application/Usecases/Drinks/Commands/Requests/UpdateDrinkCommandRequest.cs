using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Requests;

public class UpdateDrinkCommandRequest : IRequest
{
    required public Guid Id { get; set; }

    required public string Name { get; set; }

    public string? Description { get; set; }
}
