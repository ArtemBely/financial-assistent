using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Views
{
    public interface IUserLoginView
    {
        string Email { get; }
        string Password { get; }

        void ShowErrorMessage(string message);
        void ClearForm();
        void NavigateToMainPage();
        void LoginSuccessful(User user);
    }

}
