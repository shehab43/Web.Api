using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class PackageFeatureConfiguration : IEntityTypeConfiguration<PackageFeature>
    {
        public void Configure(EntityTypeBuilder<PackageFeature> builder)
        {
            builder.HasKey(pf => pf.Id);
            
            builder.Property(pf => pf.Value)
                .HasMaxLength(100);
                
            builder.Property(pf => pf.IsEnabled)
                .HasDefaultValue(true);
                
            builder.Property(pf => pf.SortOrder)
                .HasDefaultValue(0);
                
            // Configure relationships
            builder.HasOne(pf => pf.Package)
                .WithMany(p => p.PackageFeatures)
                .HasForeignKey(pf => pf.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasOne(pf => pf.Feature)
                .WithMany(f => f.PackageFeatures)
                .HasForeignKey(pf => pf.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Composite unique index to prevent duplicate package-feature combinations
            builder.HasIndex(pf => new { pf.PackageId, pf.FeatureId }).IsUnique();
            
            // Indexes
            builder.HasIndex(pf => pf.PackageId);
            builder.HasIndex(pf => pf.FeatureId);
            builder.HasIndex(pf => pf.IsEnabled);
            builder.HasIndex(pf => pf.SortOrder);
        }
    }
}
