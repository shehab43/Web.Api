using Domain.Entities.Users;

namespace Domain.Abstractions.Contracts
{
    public interface IPackageFeatureService
    {
        Task<bool> HasFeatureAsync(int packageId, string featureName);
        Task<T?> GetFeatureValueAsync<T>(int packageId, string featureName);
        Task<List<Feature>> GetPackageFeaturesAsync(int packageId);
        Task<Dictionary<string, object>> GetAllPackageFeaturesAsync(int packageId);
        Task<bool> IsFeatureEnabledAsync(int packageId, string featureName);
    }
}
