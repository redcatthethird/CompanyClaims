using CompanyClaims.Core.Models;

namespace CompanyClaims.Data;

public static class SeedingExtensions
{
    public static async Task AddSeedData(this DefaultDbContext context)
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
            Id = 2,
            Name = "CompanyB",
            Country = "UK",
            IsActive = true,
            InsuranceEndDate = DateTime.UtcNow.AddDays(-1),
        };

        await context.Database.EnsureCreatedAsync();

        context.Companies.AddRange(companyA, companyB);

        await context.SaveChangesAsync();
    }
}
