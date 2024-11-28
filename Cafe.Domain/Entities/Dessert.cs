using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Entities;

public class Dessert : Base
{
    public string Name { get; set; } = string.Empty;

    public int Calories { get; set; }

    public float Price { get; set; }
}
