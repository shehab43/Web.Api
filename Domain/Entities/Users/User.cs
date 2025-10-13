using Domain.Entities.Patients;

namespace Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Phone { get; set; }
        public Role Role { get; set; } = Role.Doctor;
        public Gender Gender { get; set; } = null!;

                    // Direct package assignment
        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;

        /// <summary>
        /// Checks if the user has an active subscription based on package duration
        /// </summary>
        /// <returns>True if the user has a valid subscription</returns>
        public bool HasActiveSubscription()
        {
            if (Package == null) return false;
            
            var subscriptionEndDate = CreatedOn.AddDays(Package.DurationInDays);
            return DateTime.UtcNow <= subscriptionEndDate;
        }

        /// <summary>
        /// Gets the subscription end date
        /// </summary>
        /// <returns>Subscription end date</returns>
        public DateTime GetSubscriptionEndDate()
        {
            return Package != null ? CreatedOn.AddDays(Package.DurationInDays) : DateTime.MinValue;
        }

        /// <summary>
        /// Gets the current package name
        /// </summary>
        /// <returns>Package name or empty string if no package</returns>
        public string GetCurrentPackageName()
        {
            return Package?.Name ?? string.Empty;
        }
    }
}
