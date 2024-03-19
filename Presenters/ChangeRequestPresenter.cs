using FinancialAssistent.Models;
using FinancialAssistent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Presenters
{
    public class ChangeRequestPresenter
    {
        private readonly IChangeRequestService _changeRequestService;


        public ChangeRequestPresenter(Views.ChangeRequestForm changeRequestForm)
        {
        }

        public ChangeRequestPresenter(Views.ChangeRequestForm changeRequestForm, IChangeRequestService changeRequestService)
        {
            _changeRequestService = changeRequestService;
        }

        public void SaveChangeRequest(ChangeRequest changeRequest)
        {
            _changeRequestService.AddChangeRequest(changeRequest);
        }

        public ChangeRequest FindPendingRequestByUserId(int userId)
        {
            return _changeRequestService.FindPendingRequestByUserId(userId);
        }
        
    }

}
