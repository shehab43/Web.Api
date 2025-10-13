using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
                   
            builder.Property(c => c.Addrees)
                   .IsRequired()
                   .HasMaxLength(50);
                   
            var contactsConverter = new ValueConverter<List<KeyValue>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => string.IsNullOrWhiteSpace(v)
                        ? new List<KeyValue>()
                        : (JsonSerializer.Deserialize<List<KeyValue>>(v, (JsonSerializerOptions?)null) ?? new List<KeyValue>())
            );

            var contactsComparer = new ValueComparer<List<KeyValue>>(
                (a, b) => (a == null && b == null) || (a != null && b != null && a.SequenceEqual(b)),
                v => v == null ? 0 : v.Aggregate(0, (acc, kv) => HashCode.Combine(acc, kv.GetHashCode())),
                v => v == null ? new List<KeyValue>() : v.ToList()
            );

            var contactsProp = builder.Property(c => c.Contacts);

            contactsProp.HasConversion(contactsConverter);
            contactsProp.HasColumnType("nvarchar(max)");
            contactsProp.Metadata.SetValueComparer(contactsComparer);

            builder.HasMany(c => c.Staff)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
