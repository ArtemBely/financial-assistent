using FinancialAssistent.Models;
using FinancialAssistent.Repositories;

namespace FinancialAssistent.Services
{
    public class AdminService : IAdminService
    {
        private readonly string _connectionString;

        private AdminRepository _adminRepository;

        public AdminService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _adminRepository = new AdminRepository(_connectionString);
        }
        public List<User> FetchUsers()
        {
            return _adminRepository.FetchUsers();
        }
    }
}
