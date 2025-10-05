using Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityTypeConfiguration
{
    public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PaidAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ReferenceNumber)
                .HasMaxLength(100);

            builder.Property(p => p.Notes)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(p => p.ServiceSession)
                .WithMany(s => s.PaymentTransactions)
                .HasForeignKey(p => p.ServiceSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Collector)
                .WithMany()
                .HasForeignKey(p => p.CollectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.TransactionDate);
            builder.HasIndex(p => p.ReferenceNumber);
        }
    }
}
