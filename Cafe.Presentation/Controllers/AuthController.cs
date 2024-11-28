using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Login;
using Cafe.Application.Usecases.Users.Commands.Registration;
using Cafe.Presentation.Common.Requests.Users;
using Events.Application.Users.Commands.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync([FromBody] RegistrationRequest request,
            CancellationToken token = default)
        {
            var command = mapper.Map<RegistrationCommandRequest>(request);

            var response = await mediator.Send(command, token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken token = default)
        {
            var command = mapper.Map<LoginCommandRequest>(request);

            var response = await mediator.Send(command, token);

            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken token = default)
        {
            var command = mapper.Map<RefreshTokenCommandRequest>(request);

            var response = await mediator.Send(command, token);

            return Ok(response);
        }
    }
}
