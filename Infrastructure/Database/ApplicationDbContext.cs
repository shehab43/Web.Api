using Application.Abstractions;
using Domain.Entities;
using Domain.Entities.Patients;
using Domain.Entities.Cases;
using Domain.Entities.Users;
using Infrastructure.Excetension;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedKernel;

namespace Infrastructure.Database
{
    public class ApplicationDbContext(
                 DbContextOptions<ApplicationDbContext> options,
                 IHttpContextAccessor httpContextAccessor
               )
                 : DbContext(options)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;
        public DbSet<PackageFeature> PackageFeatures { get; set; } = null!;
        public DbSet<Clinic> Clinics { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            // Seed default package
            SeedDefaultPackage(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private void SeedDefaultPackage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    Id = 1,
                    Name = "Basic Plan",
                    Description = "Basic clinic management features - Free trial",
                    Price = 0,
                    DurationInDays = 30,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedById = "system"
                }
            );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var entries = ChangeTracker.Entries<BaseEntity>();

            // Collect domain events before saving


            // Update audit fields
            foreach (var entityentry in entries)
            {
                if (entityentry.State == EntityState.Added)
                {
                    entityentry.Entity.CreatedById = currentUserId ?? string.Empty;
                    entityentry.Entity.CreatedOn = DateTime.UtcNow;
                }
                else if (entityentry.State == EntityState.Modified)
                {
                    if (currentUserId != null)
                    {
                        entityentry.Entity.UpdatedById = currentUserId ??  string.Empty;
                        entityentry.Entity.UpdatedOn = DateTime.UtcNow;
                    }
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;

        }

    }
}