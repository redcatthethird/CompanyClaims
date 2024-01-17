using CompanyClaims.Api.Dtos;
using CompanyClaims.Core.Models;
using CompanyClaims.Data;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Api.Services;

public class ClaimService(DefaultDbContext context)
{
    public Task<Claim?> GetClaim(string ucr) => context.Claims.FirstOrDefaultAsync(c => c.UniqueClaimReference == ucr);

    public async Task<bool> TryUpdateClaim(string ucr, ClaimUpdateDto newClaim)
    {
        var claim = await GetClaim(ucr);
        if (claim == null)
        {
            return false;
        }

        claim.LossDate = newClaim.LossDate;
        claim.AssuredName = newClaim.AssuredName;
        claim.IncurredLoss = newClaim.IncurredLoss;
        claim.IsClosed = newClaim.IsClosed;

        await context.SaveChangesAsync();

        return true;
    }
}
