using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using SharedKernel;
using Domain.Abstractions.Contracts;
using SharedKernel.Dtos.Clincs;         
namespace Application.UseCases.Clincs.Commands.CreateClinc
{
    public class CreateClincCommandHandler:IRequestHandler<CreateClincCommand,Result<int>>
    {
        private readonly IGenericRepository<Clinic> _genericRepository;

        public CreateClincCommandHandler(IGenericRepository<Clinic> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Result<int>> Handle(CreateClincCommand request, CancellationToken cancellationToken)
        {
            // Convert Dictionary to List<KeyValue>
            var contacts = request.ClincDto.Contacts?.Select(kv => new KeyValue
            {
                Key = kv.Key,
                Value = kv.Value
            }).ToList();

            var clinic = new Clinic
            {           
                Name = request.ClincDto.Name,
                Addrees = request.ClincDto.Addrees,
                Contacts = contacts,
                DoctorId = request.ClincDto.DoctorId
            };
            
            await _genericRepository.AddAsync(clinic, cancellationToken);
            await _genericRepository.SaveChangesAsync(cancellationToken);
            
            return Result.Success(clinic.Id);
        }
    }
}
