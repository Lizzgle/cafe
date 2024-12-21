using MediatR;

namespace Cafe.Application.Usecases.Prices.Commands.Requests;

public class DeletePriceCommandRequest : IRequest
{
    required public Guid Id { get; set; }
}
