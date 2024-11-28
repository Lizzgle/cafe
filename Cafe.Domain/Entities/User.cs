using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Entities;

public class User : Base
{
    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiry { get; set; }

    public List<Role> Roles { get; set; } = new List<Role>();

    public List<Feedback> Feedbacks { get; set; } = new();
}
