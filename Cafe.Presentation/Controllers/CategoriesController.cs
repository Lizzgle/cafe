using Cafe.Application.Usecases.Drinks.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cafe.Application.Usecases.Categories.Queries.Requests;

namespace Cafe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken token)
        {
            var request = new GetCategoriesQueryRequest();

            var desertsdto = await mediator.Send(request, token);

            return Ok(desertsdto);
        }

    }
}
