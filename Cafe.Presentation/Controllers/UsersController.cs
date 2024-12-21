using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Application.Usecases.Users.Queries.Requests;
using Cafe.Presentation.Common.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = PolicyTypes.ClientPolicy)]
    public async Task<IActionResult> GetMeByIdAsync(CancellationToken token)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

    [HttpPut]
    [Authorize(Policy = PolicyTypes.ClientPolicy)]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateRequest request,  CancellationToken token)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var command = mapper.Map<UpdateUserCommandRequest>(request);

        command.Id = Guid.Parse(id);

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyTypes.ModeratorPolicy)]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteUserCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Policy = PolicyTypes.ClientPolicy)]
    public async Task<IActionResult> DeleteMeAsync(CancellationToken token)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var request = new DeleteUserCommandRequest() { Id = Guid.Parse(id) };

        await mediator.Send(request, token);

        return Ok();
    }
}
