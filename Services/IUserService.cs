using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
