using Cafe.Application.Common.DTOs.Prices;

namespace Cafe.Application.Common.DTOs.Drinks;

internal class DrinkDto
{
    required public Guid Id { get; set; }

    required public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    required public string CategoryName { get; set; }

    public List<PriceDto> Prices { get; set; } = new List<PriceDto>();
}
