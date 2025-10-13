
using Domain.Entities.Users;

namespace Domain.Entities.Patients
{
    public class Patient : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Phone { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        
        // Navigation properties
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<PatientHistory> PatientHistory { get; set; } = new List<PatientHistory>();
    }
}
