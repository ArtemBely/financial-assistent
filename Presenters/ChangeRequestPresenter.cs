using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;
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
        private AdminRequestsForm adminRequestsForm;
        private ChangeRequestForm changeRequestForm;


        public ChangeRequestPresenter(ChangeRequestForm changeRequestForm, IChangeRequestService changeRequestService)
        {
            this.changeRequestForm = changeRequestForm;
            _changeRequestService = changeRequestService;
        }

        public ChangeRequestPresenter(AdminRequestsForm adminRequestsForm, IChangeRequestService changeRequestService)
        {
            this.adminRequestsForm = adminRequestsForm;
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

        public void LoadRequests()
        {
            var requests = _changeRequestService.GetAllChanges();
            adminRequestsForm.UpdateChangeRequestsList(requests);
        }

        public void UpdateChangeRequest(ChangeRequest changeRequest)
        {
            if (changeRequest == null)
                throw new ArgumentNullException(nameof(changeRequest));

            try
            {
                _changeRequestService.UpdateChangeRequest(changeRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mistake in ChangeRequest: {ex.Message}");
            }
        }

    }

}
