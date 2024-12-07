using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Application.Usecases.Users.Queries.Requests;
using Cafe.Presentation.Common.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cafe.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new GetUserByIdQueryRequest() { Id = id };

        var eventdto = await mediator.Send(request, token);

        return Ok(eventdto);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMeUserByIdAsync(CancellationToken token)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var request = new GetUserByIdQueryRequest() { Id = Guid.Parse(id) };

        var eventdto = await mediator.Send(request, token);

        return Ok(eventdto);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync(CancellationToken token)
    {
        var request = new GetUsersQueryRequest();

        var eventdto = await mediator.Send(request, token);

        return Ok(eventdto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UpdateRequest request,  CancellationToken token)
    {
        var command = mapper.Map<UpdateUserCommandRequest>(request);

        command.Id = id;

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteUserCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
