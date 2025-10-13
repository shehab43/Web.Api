using Domain.Abstractions.Contracts;
using Domain.Entities;
using Domain.Entities.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.UseCases.Clincs.Commands.CreateClinc
{
    internal sealed class CreateClincValidator : AbstractValidator<CreateClincCommand>
    {
        private readonly IGenericRepository<Clinic> _genericRepository;
        private readonly IGenericRepository<User> _userRepository;
        public CreateClincValidator(IGenericRepository<Clinic> genericRepository, IGenericRepository<User> userRepository, IGenericRepository<Package> packageRepository)
        {
            _genericRepository = genericRepository;
            _userRepository = userRepository;

            RuleFor(c => c.ClincDto.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MinimumLength(5).WithMessage("clinc name MinimumLength 5")
                .MaximumLength(50).WithMessage("clinc name MaximumLength 50");

            RuleFor(c => c.ClincDto.Addrees)
                .NotEmpty()
                .WithMessage("Addrees is required.")
                .MinimumLength(5).WithMessage("clinc Addrees MinimumLength 5")
                .MaximumLength(50).WithMessage("clinc Addrees MaximumLength 50"); ;

            RuleFor(c => c.ClincDto.Contacts)
                .NotEmpty()
                .WithMessage("Contacts is required.")
                ;

            RuleFor(c => c.ClincDto.DoctorId)
                .NotEmpty()
                .WithMessage("DoctorId is required.");


            RuleFor(c => c)
                .NotEmpty()
                .WithMessage("PackageId is required.");

           

            RuleFor(c => c.ClincDto.DoctorId)
               .MustAsync(DoctorIdExists)
               .WithMessage("DoctorId must be unique in users.");



        }

        // check doctorIdExists or not 
        private async Task<bool> DoctorIdExists(int doctorId, CancellationToken cancellationToken)=>     
            await _userRepository.AnyAsync(x => x.Id == doctorId,cancellationToken);
        
        private async Task<bool> CheckDoctorClincandbackage(int doctorid , CancellationToken cancellationToken )
        {
          var user =  _userRepository.GetAll(u => u.Id == doctorid , cancellationToken)
                          .Select(u => new { u.PackageId })
                          .FirstOrDefault();

            // packageid "1" for testing we will investigate in package entity

            if (user.PackageId != 1 ) 
                return false;
            return true;
        }
     

        private async Task<int> CheckClincCount(int doctorid, CancellationToken cancellationToken)=>
             _genericRepository.GetAll(u => u.Id == doctorid, cancellationToken).Count();
        









    }
}
