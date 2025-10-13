using Application.UseCases.Clincs.Commands.CreateClinc;
using Application.UseCases.Users.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Dtos.Clincs;
using Web.Api.Infrastructure;

namespace Web.Api.Controllers
{
    [Route("Clincs")]
    [ApiController]
    public class ClincsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("NewClinc")]
        public async Task<IResult> NewClinc([FromBody] CreateClincDto clincDto)
        {
            var command = new CreateClincCommand(clincDto);

            var result = await mediator.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : result.Problem();
        }

    }
}
