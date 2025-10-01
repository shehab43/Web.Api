using Domain.Entities.Users;
using Domain.Entities.BaseEntity;

namespace Domain.Entities.Patients
{
    public class PatientHistory:BaseEntity
    {
        public string Diagnosis { get; set; } = string.Empty;
        public string Treatment { get; set;} = string.Empty;

        public int DoctorId { get; set; } // Doctor
        public User Doctor { get; set; } = null!; // Doctor

        public int PatientId { get; set; } // Patient entity
        public Patient Patient { get; set; } = null!; // Patient entity

    }
}
