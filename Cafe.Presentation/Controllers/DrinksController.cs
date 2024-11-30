using AutoMapper;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Application.Usecases.Drinks.Queries.Requests;
using Cafe.Presentation.Common.Requests.Drinks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers;

[Route("api/drinks")]
[ApiController]
public class DrinksController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDrinkAsync([FromBody] CreateDrinkRequest request, CancellationToken token = default)
    {
        var command = mapper.Map<CreateDrinkCommandRequest>(request);

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDrinkAsync([FromRoute] Guid id, [FromBody] UpdateDrinkRequest request, CancellationToken token)
    {
        var command = mapper.Map<UpdateDrinkCommandRequest>(request);

        command.Id = id;

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetDrinksAsync(CancellationToken token)
    {
        var request = new GetDrinksQueryRequest();

        var desertsdto = await mediator.Send(request, token);

        return Ok(desertsdto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDrinkByIdAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new GetDrinkByIdQueryRequest { Id = id };

        var drinkdto = await mediator.Send(request, token);

        return Ok(drinkdto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrinkAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteDrinkCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
