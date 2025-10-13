using MediatR;
using SharedKernel;
using SharedKernel.Dtos.Clincs;
namespace Application.UseCases.Clincs.Commands.CreateClinc
{
    public record CreateClincCommand(CreateClincDto ClincDto):IRequest<Result<int>>;
   
}
