using MediatR;
using SharedKernel;
using SharedKernel.Dtos.User;
using SharedKernel.ViewModels.Users;

namespace Application.UseCases.Users.Command.Register
{
    public sealed record RegisterUserCommand(
       RegisterUserRequestDto  RegisterUserDto
    ) : IRequest<Result<RegisterViewModel>>;
}
