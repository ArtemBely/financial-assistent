using FinancialAssistent.Models;
using FinancialAssistent.Presenters;

namespace FinancialAssistent.Views
{
    public partial class LoginForm : Form, IUserLoginView
    {
        private UserLoginPresenter _presenter;

        public LoginForm()
        {
            InitializeComponent();
            _presenter = new UserLoginPresenter(this);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            _presenter.Login(emailTextBox.Text, passwordTextBox.Text);
        }

        public string Email => emailTextBox.Text;
        public string Password => passwordTextBox.Text;

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Mistake", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ClearForm()
        {
            emailTextBox.Clear();
            passwordTextBox.Clear();
        }

        public void NavigateToMainPage()
        {
            Hide();
        }

        public void LoginSuccessful(User user)
        {
            Hide();
            UserProfileForm userProfileForm = new UserProfileForm(user);
            userProfileForm.FormClosed += (s, args) => Show();
            userProfileForm.Show();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
