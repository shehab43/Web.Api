namespace Domain.Entities.Cases
{
    public class Service : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
                
        // it will be used to group services by category like "Dental", "General", etc. 
        public string Category { get; set; } = string.Empty; 
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<CaseSession> CaseSessions { get; set; } = new List<CaseSession>();
    }
}
