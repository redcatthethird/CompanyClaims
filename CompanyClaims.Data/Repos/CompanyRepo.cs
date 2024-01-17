using CompanyClaims.Core.Models;
using CompanyClaims.Data.Repos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CompanyClaims.Data.Repos;

public class CompanyRepo(DefaultDbContext context) : ICompanyRepo
{
    public Task<Company?> GetById(int id) =>
        context.Companies.Include(c => c.Claims).FirstOrDefaultAsync(c => c.Id == id);

    public Task<List<Company>> GetAll() => context.Companies.ToListAsync();
}
