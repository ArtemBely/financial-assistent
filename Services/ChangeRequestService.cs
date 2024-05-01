using FinancialAssistent.Models;
using FinancialAssistent.Repositories;

namespace FinancialAssistent.Services
{
    public class ChangeRequestService : IChangeRequestService
    {
        private readonly string _connectionString;

        private ChangeRequestRepository _repository;

        public ChangeRequestService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _repository = new ChangeRequestRepository(_connectionString);
        }
        public void AddChangeRequest(ChangeRequest changeRequest)
        {
            _repository.AddChangeRequest(changeRequest);
        }

        public ChangeRequest FindPendingRequestByUserId(int userId)
        {
            return _repository.FindPendingRequestByUserId(userId);
        }

        public List<ChangeRequest> GetAllChanges()
        {
            return _repository.GetAllChanges();
        }

        public List<ChangeRequest> GetAllChangesByUserId(int userId)
        {
            return _repository.GetAllChangesByUserId(userId);
        }

        public void UpdateChangeRequest(ChangeRequest changeRequest)
        {
            _repository.UpdateChangeRequest(changeRequest);
        }
    }

}
