using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.SubscriptionEndDate)
                   .IsRequired();
                    
            builder.Property(s => s.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
           
        }
    }
}
