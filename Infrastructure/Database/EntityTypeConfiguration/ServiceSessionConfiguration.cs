using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class ServiceSessionConfiguration : IEntityTypeConfiguration<ServiceSession>
    {
        public void Configure(EntityTypeBuilder<ServiceSession> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.ServicePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.TotalPaid)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(s => s.RemainingAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.Notes)
                .HasMaxLength(1000);

            // Relationships
            builder.HasOne(s => s.Service)
                .WithMany(s => s.ServiceSessions)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Clinic)
                .WithMany()
                .HasForeignKey(s => s.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Doctor)
                .WithMany()
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Patient)
                .WithMany()
                .HasForeignKey(s => s.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.PatientId, s.ServiceId });
            builder.HasIndex(s => s.ServiceDate);
        }
    }
}
