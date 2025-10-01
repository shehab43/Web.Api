using Domain.Entities.Patients;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Accounts
{
    public class Account : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } 
        public int UserId { get; set; }
        public int PatientId { get; set; }       
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
