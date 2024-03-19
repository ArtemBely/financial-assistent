using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public class ChangeRequestService : IChangeRequestService
    {
        private readonly string _connectionString;

        private ChangeRequestRepository repository;

        public ChangeRequestService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repository = new ChangeRequestRepository(_connectionString);
        }
        public void AddChangeRequest(ChangeRequest changeRequest)
        {
            repository.AddChangeRequest(changeRequest);
        }

        public ChangeRequest FindPendingRequestByUserId(int userId)
        {
            return repository.FindPendingRequestByUserId(userId);
        }
    }

}
