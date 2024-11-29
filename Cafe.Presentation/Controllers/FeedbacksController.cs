using AutoMapper;
using Cafe.Application.Usecases.Feedbacks.Commands.Requests;
using Cafe.Application.Usecases.Feedbacks.Queries.Requests;
using Cafe.Presentation.Common.Requests.Feedbacks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cafe.Presentation.Controllers;

[Route("api/feedbacks")]
[ApiController]
public class FeedbacksController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PolicyTypes.ClientPolicy)]
    public async Task<IActionResult> CreateFeedbackAsync([FromBody] CreateFeedbackRequest request, CancellationToken token = default)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var command = mapper.Map<CreateFeedbackCommandRequest>(request);

        command.UserId = Guid.Parse(userId);

        await mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetFeedbacksAsync(CancellationToken token)
    {
        var request = new GetFeedbacksQueryRequest();

        var eventdto = await mediator.Send(request, token);

        return Ok(eventdto);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = PolicyTypes.AdminPolicy)]
    public async Task<IActionResult> DeleteFeedbackAsync([FromRoute] Guid id, CancellationToken token)
    {
        var request = new DeleteFeedbackCommandRequest() { Id = id };

        await mediator.Send(request, token);

        return Ok();
    }
}
