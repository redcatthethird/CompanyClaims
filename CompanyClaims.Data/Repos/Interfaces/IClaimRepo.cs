using CompanyClaims.Core.Models;

namespace CompanyClaims.Data.Repos.Interfaces;

public interface IClaimRepo
{
    Task<Claim?> GetByUcr(string ucr);

    Task Update(Claim claim);
}
