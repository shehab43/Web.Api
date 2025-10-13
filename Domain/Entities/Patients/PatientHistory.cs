using Domain.Entities.Users;

namespace Domain.Entities.Patients
{
    public class PatientHistory:BaseEntity
    {
        public List<string> Diagnosis { get; set; } = new List<string>();
        public List<string> Treatment { get; set; } = new List<string>();

        public int DoctorId { get; set; } // Doctor
        public User Doctor { get; set; } = null!; // Doctor

        public int PatientId { get; set; } // Patient entity
        public Patient Patient { get; set; } = null!; // Patient entity

    }
}
