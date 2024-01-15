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
        // TODO: define actual column names and concrete SQL types
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Claims)
            .WithOne(c => c.Company);

        modelBuilder.Entity<Claim>()
            .HasKey(c => c.UniqueClaimReference);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("inMemoryDb");
    }
}
