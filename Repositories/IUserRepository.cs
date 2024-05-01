using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
        bool VerifyUserCredentials(string email, string passwordHash);
    }

}
