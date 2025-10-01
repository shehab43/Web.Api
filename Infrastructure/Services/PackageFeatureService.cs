using Domain.Abstractions.Contracts;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PackageFeatureService : IPackageFeatureService
    {
        private readonly ApplicationDbContext _context;

        public PackageFeatureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasFeatureAsync(int packageId, string featureName)
        {
            return await _context.PackageFeatures
                .Include(pf => pf.Feature)
                .AnyAsync(pf => pf.PackageId == packageId && 
                               pf.Feature.Name == featureName && 
                               pf.IsEnabled);
        }

        public async Task<T?> GetFeatureValueAsync<T>(int packageId, string featureName)
        {
            var packageFeature = await _context.PackageFeatures
                .Include(pf => pf.Feature)
                .FirstOrDefaultAsync(pf => pf.PackageId == packageId && 
                                          pf.Feature.Name == featureName && 
                                          pf.IsEnabled);

            if (packageFeature == null)
                return default(T);

            try
            {
                return (T)Convert.ChangeType(packageFeature.Value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public async Task<List<Feature>> GetPackageFeaturesAsync(int packageId)
        {
            return await _context.PackageFeatures
                .Include(pf => pf.Feature)
                .Where(pf => pf.PackageId == packageId && pf.IsEnabled)
                .Select(pf => pf.Feature)
                .OrderBy(f => f.SortOrder)
                .ToListAsync();
        }

        public async Task<Dictionary<string, object>> GetAllPackageFeaturesAsync(int packageId)
        {
            var packageFeatures = await _context.PackageFeatures
                .Include(pf => pf.Feature)
                .Where(pf => pf.PackageId == packageId && pf.IsEnabled)
                .OrderBy(pf => pf.SortOrder)
                .ToListAsync();

            var result = new Dictionary<string, object>();
            
            foreach (var pf in packageFeatures)
            {
                object value = pf.Feature.FeatureType switch
                {
                    "Boolean" => bool.Parse(pf.Value),
                    "Numeric" => int.Parse(pf.Value),
                    "Text" => pf.Value,
                    _ => pf.Value
                };
                
                result[pf.Feature.Name] = value;
            }

            return result;
        }

        public async Task<bool> IsFeatureEnabledAsync(int packageId, string featureName)
        {
            return await _context.PackageFeatures
                .Include(pf => pf.Feature)
                .AnyAsync(pf => pf.PackageId == packageId && 
                               pf.Feature.Name == featureName && 
                               pf.IsEnabled &&
                               pf.Feature.FeatureType == "Boolean" &&
                               bool.Parse(pf.Value));
        }
    }
}
