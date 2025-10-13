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
        public Status Status { get; set; } = Status.Scheduled;
        public List<string> Notes { get; set; } = new List<string>();
        public int  ClinicId { get; set; } 
        public Clinic Clinic { get; set; } 

        public int PatientId { get; set; } // Patient entity
        public Patient Patient { get; set; } = null!; // Patient entity

        public int UserId { get; set; } // Doctor/Nurse handling the booking
        public User User { get; set; } = null!; // Doctor/Nurse


    }
}
