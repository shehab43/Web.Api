namespace Domain.Entities.Users
{
    public class PackageFeature : BaseEntity
    {
        public int PackageId { get; set; }
        public Package Package { get; set; } = null!;
        
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } = null!;
        
        public string Value { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int SortOrder { get; set; }
    }
}
