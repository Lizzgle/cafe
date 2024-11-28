using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Entities;

public class Role
{
    public static Role Client => new(1, "client");

    public static Role Admin => new(2, "admin");

    public int Id { get; set; }

    public string Name { get; set; }

    protected Role(int id, string name)
    {
        Id = id;
        Name = name.ToLower();
    }

    public override string ToString() => Name;

    public static explicit operator int(Role role) => role.Id;
}
