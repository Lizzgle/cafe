﻿namespace Cafe.Domain.Entities;

public class Role
{
    public static Role Client => new(1, "client");

    public static Role Moderator => new(2, "moderator");

    public static Role Admin => new(3, "admin");

    public int Id { get; set; }

    public string Name { get; set; }

    public Role(int id, string name)
    {
        Id = id;
        Name = name.ToLower();
    }

    public override string ToString() => Name;

    public static explicit operator int(Role role) => role.Id;
}
