
using Cafe.Domain.Enums;

namespace Cafe.Domain.Entities;

public class Price : Base
{
    public float Cost { get; set; }

    public Guid DrinkId { get; set; }

    public int SizeId { get; set; }

    public Drink Drink { get; set; }

    public Size Size { get; set; }
}
