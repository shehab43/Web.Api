using System.Collections.Generic;

namespace Domain.Entities.Users
{
    public class Package : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<PackageFeature> PackageFeatures { get; set; } = new List<PackageFeature>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
