using MediatR;

namespace Cafe.Application.Usecases.Prices.Commands.Requests;

public class CreatePriceCommandRequest : IRequest
{
    required public Guid DrinkId { get; set; }

    required public string SizeName { get; set;}

    required public float Cost {  get; set; } 
}
