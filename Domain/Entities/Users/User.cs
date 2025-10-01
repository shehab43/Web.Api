using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Phone { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionTimeOut { get; set; } 
    }
}
