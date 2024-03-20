using FinancialAssistent.Services;
using FinancialAssistent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Presenters
{
    internal class AdminPresenter
    {

        private AdminDashboardForm adminDashboardForm;
        private IAdminService _adminService;

        public AdminPresenter(AdminDashboardForm adminDashboardForm, AdminService adminService)
        {
            this.adminDashboardForm = adminDashboardForm;
            _adminService = adminService;
        }

        public void LoadCustomers()
        {
            var users = _adminService.FetchUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.UserId}, Date: {user.DateOfBirth}, Amount: {user.Email}");
            }
            adminDashboardForm.UpdateUsersList(users);
        }
    }
}
