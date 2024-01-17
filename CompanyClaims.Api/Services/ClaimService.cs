using CompanyClaims.Api.Dtos;
using CompanyClaims.Core.Models;
using CompanyClaims.Data.Repos.Interfaces;

namespace CompanyClaims.Api.Services;

public class ClaimService(IClaimRepo repo)
{
    public Task<Claim?> GetClaim(string ucr) => repo.GetByUcr(ucr);

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

        await repo.Update(claim);

        return true;
    }
}
