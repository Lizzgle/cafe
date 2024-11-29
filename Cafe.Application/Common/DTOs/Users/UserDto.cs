using Cafe.Domain.Entities;

namespace Cafe.Application.Common.DTOs.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<Role> Roles { get; set; }
}
