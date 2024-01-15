using CompanyClaims.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Data;

public class DefaultDbContext : DbContext
{
    public DbSet<Claim> Claims { get; set; }
    public DbSet<ClaimType> ClaimTypes { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var companyA = new Company
        {
            Id = 1,
            Name = "CompanyA",
            Country = "UK",
            IsActive = true,
            InsuranceEndDate = DateTime.UtcNow.AddDays(1),
            Claims = [new Claim { UniqueClaimReference = "claim1", LossDate = DateTime.Now, IncurredLoss = 3.14m }]
        };
        var companyB = new Company
        {
            Id = 1,
            Name = "CompanyB",
            Country = "UK",
            IsActive = true,
            InsuranceEndDate = DateTime.UtcNow.AddDays(-1),
        };

        // TODO: define actual column names and concrete SQL types
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Claims)
            .WithOne(c => c.Company);

        modelBuilder.Entity<Company>().HasData(companyA, companyB);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("inMemoryDb");
    }
}
