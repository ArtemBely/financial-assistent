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
                _presenter.InitializeChartData(_user.UserId);
            }

            private void ButtonChoose_Click(object sender, EventArgs e)
            {
                string? selectedMonth = monthComboBox.SelectedIndex > 0 ?
                                       monthComboBox.SelectedIndex.ToString().PadLeft(2, '0') :
                                       null;
                _presenter.InitializeChartData(_user.UserId, selectedMonth);
            }

            public void UpdateChart(List<DataPoint> dataPoints)
            {
                chartExpenses.Series["Series1"].Points.Clear();
                Random random = new Random();
                foreach (var point in dataPoints)
                {
                    chartExpenses.Series["Series1"].Points.Add(point);
                    Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    point.Color = randomColor;
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
                transactionForm.FormClosed += (s, args) => Show();
                transactionForm.Show();
            }

        }

    }
