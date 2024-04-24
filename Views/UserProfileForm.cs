using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Views
{
    public partial class UserProfileForm : Form, IUserProfileView
    {
        private readonly User _user;
        private readonly TransactionPresenter _presenter;
        List<Color> colors = new List<Color>
        {
            Color.FromArgb(128, 128, 192),
            Color.FromArgb(128, 158, 128),
            Color.FromArgb(184, 134, 11),
            Color.FromArgb(205, 133, 63),
            Color.FromArgb(135, 206, 235),
            Color.FromArgb(160, 82, 45),
            Color.FromArgb(119, 136, 153),
            Color.FromArgb(147, 112, 219)
        };


        public UserProfileForm(User user)
        {
            InitializeComponent();
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _presenter = new TransactionPresenter(this, new TransactionService());
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            labelFirstName.Text = $"{_user.FirstName} {_user.LastName}";
            labelEmail.Text = _user.Email;
            phoneNumberLabel.Text = _user.PhoneNumber;
            dateOfBirthContent.Text = _user.DateOfBirth.ToString("dd MMMM yyyy");
            _presenter.InitializeChartData(_user.UserId);
        }

        private void ButtonChoose_Click(object sender, EventArgs e)
        {
            string? selectedMonth = monthComboBox.SelectedIndex > 0 ?
                                   monthComboBox.SelectedIndex.ToString().PadLeft(2, '0') :
                                   null;
            _presenter.InitializeChartData(_user.UserId, selectedMonth);
        }

        private void RequestHistory_Click(object sender, EventArgs e)
        {
            Hide();
            AdminRequestsForm adminRequestsForm = new AdminRequestsForm(_user.UserId);
            adminRequestsForm.Location = Location;
            adminRequestsForm.FormClosed += (s, args) => Show();
            adminRequestsForm.Show();
        }

        public void UpdateChart(List<DataPoint> dataPoints)
        {
            chartExpenses.Series["Series1"].Points.Clear();
            int colorIndex = 0;

            foreach (var point in dataPoints)
            {
                chartExpenses.Series["Series1"].Points.Add(point);
                Color pointColor = colors[colorIndex % colors.Count];
                point.Color = pointColor;

                colorIndex++;
            }

            chartExpenses.Series["Series1"].IsValueShownAsLabel = true;
            chartExpenses.Series["Series1"].LabelForeColor = Color.Black;
            chartExpenses.Series["Series1"].LabelFormat = "{0:C}";
            chartExpenses.Series["Series1"].ChartType = SeriesChartType.Pie;
            chartExpenses.Legends[0].Enabled = true;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TransactionChoose_Click(object sender, EventArgs e)
        {
            Hide();
            TransactionForm transactionForm = new TransactionForm(_user.UserId);
            transactionForm.Location = Location;
            transactionForm.FormClosed += (s, args) => Show();
            transactionForm.Show();
        }

        private void AIHelperChoose_Click(object sender, EventArgs e)
        {
            Hide();
            AIHelperForm aIHelperForm = new AIHelperForm(_user.UserId);
            aIHelperForm.Location = Location;
            aIHelperForm.FormClosed += (s, args) => Show();
            aIHelperForm.Show();
        }

        private void EditProfileBtn_Click(object sender, EventArgs e)
        {
            ChangeRequestForm changeRequestForm = new ChangeRequestForm(_user);
            changeRequestForm.ShowDialog();
        }


    }

}
