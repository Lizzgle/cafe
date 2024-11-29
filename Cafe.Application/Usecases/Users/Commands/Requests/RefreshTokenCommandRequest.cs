using Cafe.Application.Usecases.Users.Commands.Responses;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Requests;

public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
{
    required public string Jwt { get; set; }

    required public string RefreshToken { get; set; }
}
