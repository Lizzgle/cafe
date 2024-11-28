namespace Cafe.Presentation.Common.Requests.Users;

public class RefreshTokenRequest
{
    required public string Jwt { get; set; }

    required public string RefreshToken { get; set; }
}
