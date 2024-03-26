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
        private readonly IUserService _userService;
        private AdminRequestsForm adminRequestsForm;
        private ChangeRequestForm changeRequestForm;


        public ChangeRequestPresenter(ChangeRequestForm changeRequestForm, IChangeRequestService changeRequestService, IUserService userService)
        {
            this.changeRequestForm = changeRequestForm;
            _changeRequestService = changeRequestService;
            _userService = userService;
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

        public List<ChangeRequest> GetRequestsByUser(int userId)
        {
            var requests = _changeRequestService.GetAllChangesByUserId(userId);
            adminRequestsForm.UpdateChangeRequestsList(requests);
            return requests;
        }

        public void LoadRequests()
        {
            var requests = _changeRequestService.GetAllChanges();
            adminRequestsForm.UpdateChangeRequestsList(requests);
        }

        public void UpdateUserBasedOnChangeRequest(User user)
        {
            _userService.UpdateUser(user);
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
