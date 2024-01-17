using CompanyClaims.Core.Models;

namespace CompanyClaims.Data.Repos.Interfaces
{
    public interface ICompanyRepo
    {
        Task<Company?> GetById(int id);

        Task<List<Company>> GetAll();
    }
}
