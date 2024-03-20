using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using System.Windows.Forms;

namespace FinancialAssistent.Views
{
    public partial class LoginForm : Form, IUserLoginView
    {
        private readonly UserLoginPresenter _presenter;

        public LoginForm()
        {
            InitializeComponent();
            IUserService userService = new UserService();
            _presenter = new UserLoginPresenter(this, userService);
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
            User actualUser = _presenter.GetUserByEmail(user.Email);
            if (actualUser.RoleId == 1)
            {
                UserProfileForm userProfileForm = new UserProfileForm(user);
                userProfileForm.Location = Location;
                userProfileForm.FormClosed += (s, args) => Show();
                userProfileForm.Show();
            }
            else if (actualUser.RoleId == 2)
            {
                AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
                adminDashboardForm.Location = Location;
                adminDashboardForm.FormClosed += (s, args) => Show();
                adminDashboardForm.Show();
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
