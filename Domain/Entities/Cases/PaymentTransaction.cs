using Domain.Entities.Users;

namespace Domain.Entities.Accounts
{
    public class PaymentTransaction
    {
        public DateTime Date { get; set; }
        public int CollectorId { get; set; } // UserId - who collected the payment
        public decimal PaidAmount { get; set; }
        
        // Navigation property
        public User Collector { get; set; } = null!;
    }
}
