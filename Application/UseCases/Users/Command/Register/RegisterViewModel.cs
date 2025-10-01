using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Command.Register
{
    public class RegisterViewModel()
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    };
    
}
