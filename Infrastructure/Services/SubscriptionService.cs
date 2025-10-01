using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPackageFeatureService _packageFeatureService;

        public SubscriptionService(ApplicationDbContext context, IPackageFeatureService packageFeatureService)
        {
            _context = context;
            _packageFeatureService = packageFeatureService;
        }

        public async Task<Subscription> CreateSubscriptionAsync(int userId, int packageId)
        {
            // Get the package to access duration
            var package = await _context.Packages
                .FirstOrDefaultAsync(p => p.Id == packageId);

            if (package == null)
                throw new ArgumentException($"Package with ID {packageId} not found");

            // Deactivate any existing active subscriptions for this user
            var existingSubscriptions = await _context.Subscriptions
                .Where(s => s.UserId == userId && s.IsActive)
                .ToListAsync();

            foreach (var subscription in existingSubscriptions)
            {
                subscription.IsActive = false;
            }

            // Create new subscription
            var subscription = new Subscription
            {
                UserId = userId,
                PackageId = packageId,
                SubscriptionEndDate = Subscription.CalculateEndDate(DateTime.UtcNow, package.DurationInDays),
                IsActive = true
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return subscription;
        }

        public async Task<bool> IsSubscriptionValidAsync(int userId)
        {
            var subscription = await GetActiveSubscriptionAsync(userId);
            return subscription?.IsValid() ?? false;
        }

        public async Task<bool> IsSubscriptionExpiredAsync(int userId)
        {
            var subscription = await GetActiveSubscriptionAsync(userId);
            return subscription?.IsExpired() ?? true;
        }

        public async Task<Subscription?> GetActiveSubscriptionAsync(int userId)
        {
            return await _context.Subscriptions
                .Include(s => s.Package)
                .FirstOrDefaultAsync(s => s.UserId == userId && s.IsActive);
        }

        public async Task<bool> HasFeatureAsync(int userId, string featureName)
        {
            var subscription = await GetActiveSubscriptionAsync(userId);
            if (subscription == null || !subscription.IsValid())
                return false;

            return await _packageFeatureService.HasFeatureAsync(subscription.PackageId, featureName);
        }

        public async Task<T?> GetFeatureValueAsync<T>(int userId, string featureName)
        {
            var subscription = await GetActiveSubscriptionAsync(userId);
            if (subscription == null || !subscription.IsValid())
                return default(T);

            return await _packageFeatureService.GetFeatureValueAsync<T>(subscription.PackageId, featureName);
        }
    }
}
