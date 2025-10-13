using Application.UseCases.Users.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Dtos.User;
using SharedKernel.ViewModels.Users;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
   
        public async Task<IResult> Register([FromBody] RegisterUserRequestDto request)
        {
            var command = new RegisterUserCommand(request);

            var result = await mediator.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : result.Problem();

        }
    }
}
