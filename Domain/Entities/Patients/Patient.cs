using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Patients
{
    public class Patient:BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public int phone { get; set; }

        public string Address { get; set; } = string.Empty;

        public int PationtRecordId { get; set; } 
        public int BookingId { get; set; }

        public ICollection<Booking> bookings {  get; set; } = new List<Booking>();
        public ICollection<PatientRecords> PatientRecords { get; set; } = new List<PatientRecords>();



    }
}
