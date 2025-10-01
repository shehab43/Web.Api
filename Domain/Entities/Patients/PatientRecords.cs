using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Patients
{
    public class PatientRecords
    {
        public DateTime VisitDate { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string Diagnosis { get; set; } = string.Empty;

        public string Treatment { get; set;} = string.Empty;
        public int PatientID { get; set; }
        public int UserId { get; set; }

        public ICollection<Patient> patients { get; set; } = new List<Patient>();

        public ICollection<User> users { get; set; } = new List<User>();

    }
}
