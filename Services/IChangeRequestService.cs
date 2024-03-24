using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public interface IChangeRequestService
    {
        List<ChangeRequest> GetAllChanges();
        void AddChangeRequest(ChangeRequest changeRequest);
        ChangeRequest FindPendingRequestByUserId(int userId);
        void UpdateChangeRequest(ChangeRequest changeRequest);
    }
}
