using FinancialAssistent.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
