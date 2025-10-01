using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clinc :BaseEntity
    {
        public string Addrees { get; set; } = string.Empty;

        public int phone { get; set; }

        public int NureId { get; set; }

        public ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
    }
}
