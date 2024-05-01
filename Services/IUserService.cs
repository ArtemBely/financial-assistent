using FinancialAssistent.Models;

namespace FinancialAssistent.Services
{
    public interface IUserService
    {
        User AuthenticateUser(string email, string password);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
        void RegisterUser(User user);
    }
}
