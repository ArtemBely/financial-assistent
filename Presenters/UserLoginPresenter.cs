using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
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
