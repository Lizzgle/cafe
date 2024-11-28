using MediatR;

namespace Events.Application.Users.Commands.RefreshToken;

public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
{
    required public string Jwt { get; set; }

    required public string RefreshToken { get; set; }
}
