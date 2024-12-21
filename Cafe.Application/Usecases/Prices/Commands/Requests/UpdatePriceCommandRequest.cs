using MediatR;

namespace Cafe.Application.Usecases.Prices.Commands.Requests;

public class UpdatePriceCommandRequest : IRequest
{
    required public Guid Id { get; set; }

    required public float Cost { get; set; }
}
