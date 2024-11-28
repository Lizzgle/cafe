using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.DeleteUser;

public class DeleteUserCommandRequest : IRequest
{
    required public Guid Id {  get; init; } 
}
