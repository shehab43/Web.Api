using Domain.Entities.Cases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public sealed class CaseSessionConfiguration : IEntityTypeConfiguration<CaseSession>
    {
        public void Configure(EntityTypeBuilder<CaseSession> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServicePrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.TotalPaid)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(x => x.RemainingAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.Property(x => x.ServiceDate)
                   .IsRequired();

            // Map SmartEnum SessionStatus as string value
            builder.Property(x => x.Status)
                   .HasConversion(
                        s => s.Value,
                        v => SessionStatus.FromValue(v))
                   .HasMaxLength(32)
                   .IsRequired();

            // Relationships
            builder.HasOne(x => x.Service)
                   .WithMany()
                   .HasForeignKey(x => x.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Clinic)
                   .WithMany()
                   .HasForeignKey(x => x.ClinicId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Doctor)
                   .WithMany()
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Patient)
                   .WithMany()
                   .HasForeignKey(x => x.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PaymentTransactions)
                   .WithOne(x => x.ServiceSession)
                   .HasForeignKey(x => x.CaseSessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Ignore calculated properties
            builder.Ignore(x => x.IsFullyPaid);
            builder.Ignore(x => x.IsPartiallyPaid);
        }
    }
}


