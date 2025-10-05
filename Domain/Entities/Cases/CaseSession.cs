using Domain.Entities.Patients;
using Domain.Entities.Users;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Entities.Cases
{
    public class CaseSession : BaseEntity
    {
        // Foreign Keys
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        public int DoctorId { get; set; }
        public User Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        // Service Session Details
        public decimal ServicePrice { get; set; } // Price at the time of service (can change over time)
        public decimal TotalPaid { get; set; } = 0;
        public decimal RemainingAmount { get; set; }
        public SessionStatus Status { get; set; } 
        public DateTime ServiceDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Payment Information
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();

        // Calculated Properties
        public bool IsFullyPaid => RemainingAmount <= 0;
        public bool IsPartiallyPaid => TotalPaid > 0 && TotalPaid < ServicePrice;

        // Constructor to calculate remaining amount
        public CaseSession()
        {
            CalculateRemainingAmount();
        }

        public void CalculateRemainingAmount()
        {
            RemainingAmount = ServicePrice - TotalPaid;
        }

      
        
    }
}
