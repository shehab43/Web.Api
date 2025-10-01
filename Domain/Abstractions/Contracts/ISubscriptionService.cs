using Domain.Entities.Users;

namespace Domain.Abstractions.Contracts
{
    public interface ISubscriptionService
    {
        Task<Subscription> CreateSubscriptionAsync(int userId, int packageId);
        Task<bool> IsSubscriptionValidAsync(int userId);
        Task<bool> IsSubscriptionExpiredAsync(int userId);
        Task<Subscription?> GetActiveSubscriptionAsync(int userId);
        Task<bool> HasFeatureAsync(int userId, string featureName);
        Task<T?> GetFeatureValueAsync<T>(int userId, string featureName);
    }
}
