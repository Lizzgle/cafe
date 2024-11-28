namespace Cafe.Presentation.Common.Requests.Users
{
    public class RegistrationRequest
    {
        required public string Login { get; init; }

        required public string Name { get; init; }

        required public string Password { get; init; }

        required public DateTime DateOfBirth { get; init; }
    }
}
