using System.Text.Json;
using Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.AppointmentDate)
                   .IsRequired();

            builder.Property(b => b.PatientName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Persist SmartEnum Status as string value
            builder.Property(b => b.Status)
                   .HasConversion(
                       s => s.Value,
                       v => Status.FromValue(v))
                   .HasMaxLength(32)
                   .IsRequired();

            // Convert Notes (List<string>) to JSON for storage
            var notesConverter = new ValueConverter<List<string>, string>(
                     v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                     v => string.IsNullOrWhiteSpace(v)
                             ? new List<string>()
                             : (JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
                               );
            var notesComparer = new ValueComparer<List<string>>(
                        (a, b) => (a == null && b == null) || (a != null && b != null && a.SequenceEqual(b)),
                        v => v == null ? 0 : v.Aggregate(0, (acc, s) => HashCode.Combine(acc, s.GetHashCode())),
                        v => v == null ? new List<string>() : v.ToList());

            builder.Property(b => b.Notes)
                   .HasConversion(notesConverter)
                   .Metadata.SetValueComparer(notesComparer);

            builder.Property(b => b.ClinicId)
                   .IsRequired();

            builder.HasOne(b => b.Clinic)
                   .WithMany()
                   .HasForeignKey(b => b.ClinicId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(b => b.PatientId)
                   .IsRequired();

            builder.HasOne(b => b.Patient)
                   .WithMany()
                   .HasForeignKey(b => b.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.UserId)
                   .IsRequired();

            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


