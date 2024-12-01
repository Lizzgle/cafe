using AutoMapper;
using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Application.Usecases.Desserts.Queries.Requests;
using Cafe.Presentation.Common.Requests.Desserts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers;

[Route("api/desserts")]
[ApiController]
public class DessertsController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> CreateDessertAsync([FromBody] DessertRequest request, CancellationToken token = default)
    {
        var command = mapper.Map<CreateDessertCommandRequest>(request);

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> UpdateDessertAsync([FromRoute] Guid id, [FromBody] DessertRequest request, CancellationToken token)
    {
        var command = mapper.Map<UpdateDessertCommandRequest>(request);

        command.Id = id;

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetDessertsAsync(CancellationToken token)
    {
        var request = new GetDessertsQueryRequest();

        var desertsdto = await mediator.Send(request, token);

        return Ok(desertsdto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDessertByIdAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new GetDessertByIdQueryRequest { Id = id };

        var dessertdto = await mediator.Send(request, token);

        return Ok(dessertdto);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> DeleteDessertAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteDessertCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
