using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    internal interface IChangeRequestRepository
    {
        List<ChangeRequest> GetAllChanges();
        void AddChangeRequest(ChangeRequest changeRequest);
        ChangeRequest FindPendingRequestByUserId(int userId);
        List<ChangeRequest> GetAllChangesByUserId(int userId);
        void UpdateChangeRequest(ChangeRequest changeRequest);
    }
}
