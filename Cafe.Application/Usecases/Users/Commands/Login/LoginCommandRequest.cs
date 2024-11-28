using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    required public string Login { get; init; }

    required public string Password { get; init; }
}
