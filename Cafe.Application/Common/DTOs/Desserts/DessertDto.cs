namespace Cafe.Application.Common.DTOs.Desserts;

public class DessertDto
{
    required public Guid Id { get; set; }

    required public string Name { get; set; }

    public string? Description { get; set; }

    public int Calories { get; set; }

    public float Price { get; set; }

    public List<string> Ingredients { get; set; } = new List<string>();
}
