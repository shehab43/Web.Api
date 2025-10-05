using Application.UseCases.Users.Command.Register;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public sealed record Request(string Email, string FirstName, string LastName, string Password);
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Request request)
        {
            var command = new RegisterUserCommand(request.Email, request.FirstName, request.LastName, request.Password);
            var result = await _mediator.Send(command);
            // return result.IsSuccess ? Ok(result) : result.Problem();
          return result.Match(
            Results.Ok,
            result.Problem()
          );

        }
    }
}
