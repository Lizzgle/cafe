using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Requests;

public class DeleteDrinkCommandRequest : IRequest
{
    required public Guid Id { get; set; }
}
