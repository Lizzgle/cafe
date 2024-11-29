using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Requests;

public class DeleteUserCommandRequest : IRequest
{
    required public Guid Id { get; init; }
}
