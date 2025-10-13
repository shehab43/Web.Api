using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.Role)
                   .HasConversion(
                        r => r.Value,
                        v => Role.FromValue(v))
                   .HasMaxLength(32)
                   .IsRequired();

            builder.Property(u => u.Gender)
                   .HasConversion(
                        g => g.Value,
                        v => Gender.FromValue(v))
                   .HasMaxLength(16)
                   .IsRequired();

            builder.Property(u => u.Phone)
                   .IsRequired();
                   
            builder.Property(u => u.FullName)
                   .IsRequired();

            builder.Property(u => u.Email)
                   .IsRequired();
                   
            builder.Property(u => u.Password)
                   .IsRequired();
        }
    }

}
