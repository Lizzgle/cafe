namespace Cafe.Application.Common.DTOs.Desserts;

public class ShortDessertDto
{
    required public Guid Id { get; set; }

    required public string Name { get; set; }

    public float Price { get; set; }
}
