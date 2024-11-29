using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Requests;

public class DeleteDessertCommandRequest : IRequest
{
    required public Guid Id { get; set; }
}
