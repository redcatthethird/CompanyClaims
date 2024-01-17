using CompanyClaims.Core.Models;
using CompanyClaims.Data.Repos.Interfaces;

namespace CompanyClaims.Api.Services;

public class CompanyService(ICompanyRepo repo)
{
    public Task<List<Company>> GetCompanies() => repo.GetAll();

    public Task<Company?> GetCompany(int id) => repo.GetById(id);

    public async Task<List<Claim>?> GetClaimsForCompany(int id) => (await repo.GetById(id))?.Claims;
}
