using AutoMapper;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Presentation.Common.Requests.Prices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers;

[Route("api/prices")]
[ApiController]
public class PricesController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> CreatePriceAsync([FromBody] CreatePriceRequest request, CancellationToken token = default)
    {
        var command = mapper.Map<CreatePriceCommandRequest>(request);

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> UpdatePriceAsync([FromRoute] Guid id, [FromBody] float cost, CancellationToken token)
    {
        var request = new UpdatePriceCommandRequest { Id = id, Cost = cost };

        await mediator.Send(request, token);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> DeletePriceAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeletePriceCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
