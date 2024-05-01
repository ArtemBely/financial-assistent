using FinancialAssistent.Models;

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
