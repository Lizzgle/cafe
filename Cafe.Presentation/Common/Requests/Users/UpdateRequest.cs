namespace Cafe.Presentation.Common.Requests.Users;

public class UpdateRequest
{
    required public string Name { get; init; }

    required public DateTime DateOfBirth { get; init; }
}
