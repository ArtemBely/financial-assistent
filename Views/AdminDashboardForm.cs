using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using User = FinancialAssistent.Models.User;

namespace FinancialAssistent.Views
{
    public partial class AdminDashboardForm : Form
    {

        private readonly AdminPresenter _presenter;
        public AdminDashboardForm()
        {
            InitializeComponent();
            _presenter = new AdminPresenter(this, new AdminService());
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadCustomers();
        }

        public void UpdateUsersList(List<User> users)
        {
            usersListview.Items.Clear();

            if (usersListview.Columns.Count == 0)
            {
                usersListview.Columns.Add("UserID", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("First Name", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("Email", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("Date of birth", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("Phone", -2, HorizontalAlignment.Left);
                usersListview.Columns.Add("RoleId", -2, HorizontalAlignment.Left);
            }
            foreach (var user in users)
            {
                var item = new ListViewItem($"{user.UserId}");
                item.SubItems.Add(user.FirstName);
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.Email);
                item.SubItems.Add(user.DateOfBirth.ToShortDateString());
                item.SubItems.Add(user.PhoneNumber);
                item.SubItems.Add(user.RoleId.ToString());
                usersListview.Items.Add(item);
            }

            usersListview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            usersListview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Show_Requests(object sender, EventArgs e)
        {
            Hide();
            AdminRequestsForm adminRequestsForm = new AdminRequestsForm();
            adminRequestsForm.Location = Location;
            adminRequestsForm.FormClosed += (s, args) => Show();
            adminRequestsForm.Show();
        }
    }
}
