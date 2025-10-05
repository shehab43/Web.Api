using Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Cases
{
    public class PaymentTransaction : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Foreign Keys
        public int CollectorId { get; set; } // UserId - who collected the payment
        public User Collector { get; set; } = null!;

        public int CaseSessionId { get; set; } // Which service session this payment is for
        public CaseSession ServiceSession { get; set; } = null!;
 
         }
}
