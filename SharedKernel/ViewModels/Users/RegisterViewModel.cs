namespace SharedKernel.ViewModels.Users
{
    public class RegisterViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string PackageName { get; set; } = string.Empty;
        public DateTime SubscriptionEndDate { get; set; }
        public bool HasActiveSubscription { get; set; }
    }
}
