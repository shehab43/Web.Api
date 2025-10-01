using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class Nurse : BaseEntity
    {
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
