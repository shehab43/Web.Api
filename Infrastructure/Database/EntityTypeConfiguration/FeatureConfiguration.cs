using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.Id);
            
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(f => f.Description)
                .HasMaxLength(500);
                
            builder.Property(f => f.Category)
                .IsRequired()
                .HasMaxLength(50);
                
            builder.Property(f => f.FeatureType)
                .IsRequired()
                .HasMaxLength(20);
                
            builder.Property(f => f.DefaultValue)
                .HasMaxLength(100);
                
            builder.Property(f => f.IsActive)
                .HasDefaultValue(true);
                
            builder.Property(f => f.SortOrder)
                .HasDefaultValue(0);
                
            // Configure relationships
            builder.HasMany(f => f.PackageFeatures)
                .WithOne(pf => pf.Feature)
                .HasForeignKey(pf => pf.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Indexes
            builder.HasIndex(f => f.Name).IsUnique();
            builder.HasIndex(f => f.Category);
            builder.HasIndex(f => f.IsActive);
            builder.HasIndex(f => f.SortOrder);
        }
    }
}
