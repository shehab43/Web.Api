using Application.Abstractions.Authentication;
using Ardalis.SmartEnum;
using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using MediatR;
using SharedKernel;
using SharedKernel.ViewModels.Users;

namespace Application.UseCases.Users.Command.Register
{
    internal sealed class RegisterUserCommandHandler(
        IGenericRepository<User> genericRepository,
        IGenericRepository<Package> packageRepository,
        IPasswordHasher passwordHasher
    ) : IRequestHandler<RegisterUserCommand, Result<RegisterViewModel>>
    {
        public async Task<Result<RegisterViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var trimmedEmail = request.RegisterUserDto.Email.Trim().ToLowerInvariant();    
            var user = new User
            {
                FullName = request.RegisterUserDto.FullName,
                Email = trimmedEmail,
                Password = passwordHasher.Hash(request.RegisterUserDto.Password),
                Gender = Gender.FromName(request.RegisterUserDto.Gender, true),
                Role = Role.FromName(request.RegisterUserDto.RoleName, true),
                PackageId = request.RegisterUserDto.PackageId.Value,
            };

            await genericRepository.AddAsync(user, cancellationToken);
            await genericRepository.SaveChangesAsync(cancellationToken);

            var viewModel = new RegisterViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                RoleName = user.Role.Name,
                PackageName = user.Package.Name,
                SubscriptionEndDate = user.GetSubscriptionEndDate(),
                HasActiveSubscription = user.HasActiveSubscription()
            };

            return Result.Success(viewModel);
        }

       
    }
}       