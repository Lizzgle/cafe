namespace Cafe.Domain.Entities;

public class Dessert : Base
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; }

    public int Calories { get; set; }

    public float Price { get; set; }
}
