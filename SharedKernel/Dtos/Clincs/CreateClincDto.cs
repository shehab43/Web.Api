using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Dtos.Clincs
{
    public sealed record CreateClincDto(
        string Name,
        string Addrees,
        Dictionary<string, string> Contacts,
        int  DoctorId
        );

}
