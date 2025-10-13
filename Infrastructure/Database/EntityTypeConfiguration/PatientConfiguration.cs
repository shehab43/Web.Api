using Domain.Entities.Patients;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(254);

            builder.Property(p => p.Phone)
                   .IsRequired();


            builder.Property(x => x.Gender)
                   .HasConversion(
                        s => s.Value,
                        v => Gender.FromValue(v))
                   .HasMaxLength(32)
                   .IsRequired();

            builder.Property(p => p.DateOfBirth)
                   .IsRequired();

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.HasMany(p => p.Bookings)
                   .WithOne(b => b.Patient)
                   .HasForeignKey(b => b.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


