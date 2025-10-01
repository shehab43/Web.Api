using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);
                   
            builder.Property(c => c.Addrees)
                   .IsRequired()
                   .HasMaxLength(500);
                   
            builder.Property(c => c.Contacts)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<List<KeyValue>>(v, (JsonSerializerOptions)null!) ?? new List<KeyValue>()
                   )
                   .HasColumnType("json");
                   
            builder.HasMany(c => c.Staff)
                   .WithOne()
                   .HasForeignKey(u => u.ClinicId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
