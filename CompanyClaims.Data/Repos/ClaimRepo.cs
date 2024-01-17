using CompanyClaims.Core.Models;
using CompanyClaims.Data.Repos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Data.Repos;

public class ClaimRepo(DefaultDbContext context) : IClaimRepo
{
    public Task<Claim?> GetByUcr(string ucr) =>
        context.Claims.FirstOrDefaultAsync(c => c.UniqueClaimReference == ucr);

    public Task Update(Claim claim)
    {
        context.Update(claim);
        return context.SaveChangesAsync();
    }
}
