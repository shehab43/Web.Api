using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Patients
{
    public class Booking : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }

        public string PatientName { get; set; } = string.Empty;
        public status Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int  ClincId { get; set; } 
        public int PatientID { get; set; }
        public int UserId { get; set; }
        public Clinc Clinc { get; set; } 
        public ICollection<Patient> patients = new Collection<Patient>(); 
        public ICollection<User> users = new Collection<User>();

    }
}
