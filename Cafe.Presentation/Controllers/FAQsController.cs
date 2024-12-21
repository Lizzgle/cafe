using Cafe.Application.Usecases.FAQs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers;

[Route("api/faqs")]
[ApiController]
public class FAQsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFAQsAsync(CancellationToken token)
    {
        var request = new GetFAQsQueryRequest();

        var faqs = await mediator.Send(request, token);

        return Ok(faqs);
    }
}
