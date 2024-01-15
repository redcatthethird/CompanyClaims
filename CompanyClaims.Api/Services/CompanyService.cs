using CompanyClaims.Core.Models;
using CompanyClaims.Data;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Api.Services;

public class CompanyService(DefaultDbContext context)
{
    public IEnumerable<Company> GetCompanies() => context.Companies;

    public Company? GetCompany(int id) => context.Companies.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Claim>? GetClaimsForCompany(int id) => context.Companies.Include(c => c.Claims).FirstOrDefault(c => c.Id == id)?.Claims;
}
