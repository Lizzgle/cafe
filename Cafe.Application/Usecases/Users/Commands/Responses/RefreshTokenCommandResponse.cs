namespace Cafe.Application.Usecases.Users.Commands.Responses;

public class RefreshTokenCommandResponse
{
    public string Jwt { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
