using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public class AdminService : IAdminService
    {
        private readonly string _connectionString;

        private AdminRepository adminRepository;

        public AdminService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            adminRepository = new AdminRepository(_connectionString);
        }
        public List<User> FetchUsers()
        {
            return adminRepository.FetchUsers();
        }
    }
}
