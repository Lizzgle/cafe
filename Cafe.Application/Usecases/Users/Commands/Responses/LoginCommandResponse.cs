namespace Cafe.Application.Usecases.Users.Commands.Responses;

public class LoginCommandResponse
{
    public string JwtToken { get; init; } = string.Empty;

    public string RefreshToken { get; init; } = string.Empty;
}
