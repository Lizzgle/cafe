namespace Cafe.Application.Usecases.Users.Commands.Registration;

public class RegistrationCommandResponse
{
    public string JwtToken { get; init; } = string.Empty;

    public string RefreshToken { get; init; } = string.Empty;
}
