using Cafe.Application.Common.DTOs.Prices;

namespace Cafe.Presentation.Common.Requests.Drinks;

public class CreateDrinkRequest
{
    required public string Name { get; set; }

    public string? Description { get; set; }

    required public string CategoryName { get; set; }

    public List<ShortPriceDto> Prices { get; set; } = [];

    public List<string> Ingredients { get; set; } = new List<string>();
}
