using MediatR;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Query
{
    public sealed record class GetUserIdCommand(int UserId):IRequest<Result>;
   
}
