namespace Cafe.Application.Common.DTOs.Users;

public class ShortUserDto
{
    public Guid Id { get; set; }

    public string? Login { get; set; }

    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }
}
