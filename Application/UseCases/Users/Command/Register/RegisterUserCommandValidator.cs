using Ardalis.SmartEnum;
using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.UseCases.Users.Command.Register
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IGenericRepository<Package> _packageRepository;

        public RegisterUserCommandValidator(
            IGenericRepository<User> genericRepository,
             IGenericRepository<Package> packageRepository
             )
        {
            _genericRepository = genericRepository;
            _packageRepository = packageRepository;

            RuleFor(c => c.RegisterUserDto.FullName)
                .NotEmpty()
                .WithMessage("Full name is required.")
                .MinimumLength(3)
                .WithMessage("Full name must be at least 3 characters.")
                .MaximumLength(100)
                .WithMessage("Full name must not exceed 100 characters.");

            RuleFor(c => c.RegisterUserDto.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50)
                .MustAsync(async (email, cancellationToken) =>
                {
                    return await EmailAlreadyExists(email, cancellationToken);

                })
                .WithMessage("Email already in use.");

            RuleFor(c => c.RegisterUserDto.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters.")
                .MaximumLength(20)
                .WithMessage("Password must not exceed 20 characters.");

            RuleFor(c => c.RegisterUserDto.Gender)
                .NotEmpty()
                .WithMessage("Gender is required.")
                .Must(g => string.Equals(g, "Male", StringComparison.OrdinalIgnoreCase)
                      || string.Equals(g, "Female", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Invalid gender. Allowed values: Male, Female.");

            RuleFor(c => c.RegisterUserDto.RoleName)
                .NotEmpty()
                .WithMessage("Role is required.")
                .Must(r => string.Equals(r, "Admin", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(r, "Nurse", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(r, "Doctor", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Invalid role. Allowed values: Admin, Nurse, Doctor.");

            // Optional PackageId validation
            RuleFor(c => c.RegisterUserDto.PackageId)
                .MustAsync(async (packageId, cancellationToken) =>
                {
                    return await PackageExists(packageId, cancellationToken);
                })
                .WithMessage("Package not found or is not active.");  
        }

        private async Task<bool> PackageExists(int? packageId, CancellationToken cancellationToken)
        {
            if (!packageId.HasValue) return true;

            return await _packageRepository.AnyAsync(p => p.Id == packageId.Value, cancellationToken);
        }

        private async Task<bool> EmailAlreadyExists(string email, CancellationToken cancellationToken)
        {   
            return await _genericRepository.AnyAsync(c => c.Email == email, cancellationToken);
        }   
    }
} 
