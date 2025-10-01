using Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Accounts
{
    public class CaseSession : BaseEntity
    {

        // Clinic
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        // Doctor (User with Doctor role)
        public int DoctorId { get; set; }
        public User Doctor { get; set; } = null!;


        // Patient (User with Patient role)
        public int PatientId { get; set; }
        public User Patient { get; set; } = null!;


        public SessionStatus Status { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    
        
        // Payment transactions
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();
    }
}
