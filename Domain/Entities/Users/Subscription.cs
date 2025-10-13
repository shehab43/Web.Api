using System;

namespace Domain.Entities.Users
{
    public class Subscription : BaseEntity
    {
        // One-to-One relationship with User (User has SubscriptionId)
        public User User { get; set; } = null!;

        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;

        public DateTime SubscriptionEndDate { get; set; }
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Calculates the subscription end date based on the package duration
        /// </summary>
        /// <param name="startDate">The subscription start date (usually CreatedOn)</param>
        /// <param name="packageDurationInDays">The package duration in days</param>
        /// <returns>The calculated end date</returns>
        public static DateTime CalculateEndDate(DateTime startDate, int packageDurationInDays)
        {
            return startDate.AddDays(packageDurationInDays);
        }

        /// <summary>
        /// Checks if the subscription is expired
        /// </summary>
        /// <returns>True if the subscription has expired</returns>
        public bool IsExpired()
        {
            return DateTime.UtcNow > SubscriptionEndDate;
        }


        /// <summary>
        /// Checks if the subscription is active and not expired
        /// </summary>
        /// <returns>True if the subscription is valid</returns>
        public bool IsValid()
        {
            return IsActive && !IsExpired();
        }
    }
}
