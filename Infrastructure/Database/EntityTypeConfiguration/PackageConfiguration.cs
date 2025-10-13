using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(p => p.Description)
                .HasMaxLength(500);
                
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
                
            builder.Property(p => p.DurationInDays)
                .IsRequired();
                
            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);
                
           
            // Configure relationships
            builder.HasMany(p => p.PackageFeatures)
                .WithOne(pf => pf.Package)
                .HasForeignKey(pf => pf.PackageId)
                .OnDelete(DeleteBehavior.Cascade);
                
          
                
            // Indexes
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.IsActive);
        }
    }
}
