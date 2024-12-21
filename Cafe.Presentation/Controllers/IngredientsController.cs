using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Application.Usecases.Ingredients.Commands.Requests;
using Cafe.Application.Usecases.Ingredients.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers;

[Route("api/ingredients")]
[ApiController]
public class IngredientsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> CreateIngredientAsync([FromBody] string name, CancellationToken token = default)
    {
        var request = new CreateIngredientCommandRequest() { Name = name };

        await mediator.Send(request, token);

        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> UpdateIngredientAsync([FromRoute] Guid id, [FromBody] string name, CancellationToken token)
    {
        var request = new UpdateIngredientCommandRequest() { Name = name, Id = id };

        await mediator.Send(request, token);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredientsAsync(CancellationToken token)
    {
        var request = new GetIngredientsQueryRequest();

        var desertsdto = await mediator.Send(request, token);

        return Ok(desertsdto);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> DeleteIngredientAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteDrinkCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
