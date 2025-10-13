using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using MediatR;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Query
{
    internal class GetUserIdCommandHandler : IRequestHandler<GetUserIdCommand, Result>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public GetUserIdCommandHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Result> Handle(GetUserIdCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _genericRepository.GetByIdAsync(request.UserId,cancellationToken);
                                 //.select(u => new
                                 //{
                                 //    u.Id,
                                 //    u.FullName,
                                 //    u.Email,
                                 //    u.Phone,
                                 //    u.Role,
                                 //    u.Gender,
                                 //    u.ClinicId
                                 //})
                                 //.firstordefaultasync(cancellationToken);
                                 
            return userExists is not null ? Result.Success() :
                                            Result.Failure<User>(UserErrors.NotFound(request.UserId));
        }
    }
}
