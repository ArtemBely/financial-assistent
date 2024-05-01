using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    public interface IAdminRepository
    {
        List<User> FetchUsers();
    }
}
