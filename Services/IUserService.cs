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
        void RegisterUser(User user);
    }
}
