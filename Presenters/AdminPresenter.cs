using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
    internal class AdminPresenter
    {

        private AdminDashboardForm _adminDashboardForm;
        private IAdminService _adminService;

        public AdminPresenter(AdminDashboardForm adminDashboardForm, AdminService adminService)
        {
            _adminDashboardForm = adminDashboardForm;
            _adminService = adminService;
        }

        public void LoadCustomers()
        {
            var users = _adminService.FetchUsers();
            _adminDashboardForm.UpdateUsersList(users);
        }
    }
}
