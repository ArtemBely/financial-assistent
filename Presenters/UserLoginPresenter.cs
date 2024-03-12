using FinancialAssistent.Repositories;
using FinancialAssistent.Services;
using FinancialAssistent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Presenters
{
    // Presenters/UserLoginPresenter.cs
    public class UserLoginPresenter
    {
        private readonly IUserLoginView _view;
        private readonly IUserService _userService;

        public UserLoginPresenter(IUserLoginView view)
        {
            _view = view;
            _userService = new UserService(new UserRepository());
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
    }

}
