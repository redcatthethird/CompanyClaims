using CompanyClaims.Core.Models;
using CompanyClaims.Data;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Api.Services;

public class CompanyService(DefaultDbContext context)
{
    public async Task<IEnumerable<Company>> GetCompanies()
    {
        var companies = await context.Companies.ToListAsync();
        return companies.AsEnumerable();
    }

    public Task<Company?> GetCompany(int id) => context.Companies.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Claim>?> GetClaimsForCompany(int id)
    {
        var company = await context.Companies.Include(c => c.Claims).FirstOrDefaultAsync(c => c.Id == id);
        return company?.Claims.AsEnumerable();
    }
}
