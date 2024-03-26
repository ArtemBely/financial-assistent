using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
