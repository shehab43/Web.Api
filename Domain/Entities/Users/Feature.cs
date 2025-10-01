using System.Collections.Generic;

namespace Domain.Entities.Users
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string FeatureType { get; set; } = string.Empty; // "Boolean", "Numeric", "Text"
        public string DefaultValue { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; }
        
        // Navigation properties
        public ICollection<PackageFeature> PackageFeatures { get; set; } = new List<PackageFeature>();
    }
}
