using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using FinancialAssistent.Services;
using FinancialAssistent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialAssistent.Presenters
{
    // Presenters/UserLoginPresenter.cs
    public class UserLoginPresenter
    {
        private readonly IUserLoginView _view;
        private readonly IUserService _userService;

        public UserLoginPresenter(IUserLoginView view, IUserService userService)
        {
            _view = view;
            _userService = userService;
        }


        public void Login(string email, string password)
        {
            var user = _userService.AuthenticateUser(email, password);
            if (user != null)
            {
                _view.LoginSuccessful(user);
            }
            else
            {
                _view.ShowErrorMessage("Wrong password");
            }
        }

        public User GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
        
    }

}
