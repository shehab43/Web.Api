using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class Doctor :BaseEntity
    {
        public int ClincId { get; set; }
       
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Clinc> clincs { get; set; } = new List<Clinc>();
    }
}
