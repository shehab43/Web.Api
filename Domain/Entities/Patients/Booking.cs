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
        public int  ClinicId { get; set; } 
        public int PatientId { get; set; } // Patient entity
        public int UserId { get; set; } // Doctor/Nurse handling the booking
        public Clinic Clinic { get; set; } 
        public Patient Patient { get; set; } = null!; // Patient entity
        public User User { get; set; } = null!; // Doctor/Nurse

    }
}
