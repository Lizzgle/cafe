using Cafe.Domain.Enums;

namespace Cafe.Domain.Entities;

public class Drink : Base
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public List<Size> Sizes { get; set; } = new List<Size>();

    public List<Price> Prices { get; set; } = new List<Price>();
}
