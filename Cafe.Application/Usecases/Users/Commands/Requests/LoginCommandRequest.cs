using Cafe.Application.Usecases.Users.Commands.Responses;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Requests;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    required public string Login { get; init; }

    required public string Password { get; init; }
}
