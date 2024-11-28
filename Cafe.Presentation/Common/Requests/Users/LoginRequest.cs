namespace Cafe.Presentation.Common.Requests.Users;

public class LoginRequest
{
    required public string Login { get; init; }

    required public string Password { get; init; }
}
