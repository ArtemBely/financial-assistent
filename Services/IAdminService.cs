using FinancialAssistent.Models;

namespace FinancialAssistent.Services
{
    internal interface IAdminService
    {
        List<User> FetchUsers();
    }
}
