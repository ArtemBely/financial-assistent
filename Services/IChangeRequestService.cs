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
        void AddChangeRequest(ChangeRequest changeRequest);
        ChangeRequest FindPendingRequestByUserId(int userId);
    }
}
