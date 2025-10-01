using Application.Abstractions.Authentication;
using Azure;
using Azure.Core;
using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel;


namespace Application.UseCases.Users.Command.Register
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,Result>
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IPasswordHasher _passwordHasher;
   
        private readonly ILogger<RegisterUserCommandHandler> _logger;

        public RegisterUserCommandHandler(
            IGenericRepository<User> genericRepository,
            IPasswordHasher passwordHasher,
          
            ILogger<RegisterUserCommandHandler> logger
            )
        {
            _genericRepository = genericRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            if (await _genericRepository.AnyAsync(u => u.Email == request.Email)) 
            {
                return Result.Failure<RegisterViewModel>(UserErrors.EmailNotUnique);
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = _passwordHasher.Hash(request.Password)
            };
             var users =  await _genericRepository.AddAsync(user);
             var reslt =  await _genericRepository.SaveChangesAsync(cancellationToken);
        
            return Result.Success();


        }
    }
}
