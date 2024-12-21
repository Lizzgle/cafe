using Cafe.Application.Common.DTOs.Prices;
using MediatR;

namespace Cafe.Application.Usecases.Drinks.Commands.Requests;

public class CreateDrinkCommandRequest : IRequest
{
    required public string Name { get; set; }

    public string? Description { get; set; }

    required public string CategoryName { get; set; }

    public List<ShortPriceDto> Prices { get; set; } = [];

    public List<string> Ingredients { get; set; } = new List<string>();
}
