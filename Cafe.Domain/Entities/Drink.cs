using Cafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Entities;

public class Drink : Base
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Size Size { get; set; }

    public float Price { get; set; }

    public Category? Category { get; set; }
}
