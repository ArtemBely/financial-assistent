using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
    public class ChangeRequestPresenter
    {
        private readonly IChangeRequestService _changeRequestService;
        private readonly IUserService _userService;
        private AdminRequestsForm _adminRequestsForm;
        private ChangeRequestForm _changeRequestForm;


        public ChangeRequestPresenter(ChangeRequestForm changeRequestForm, IChangeRequestService changeRequestService, IUserService userService)
        {
            _changeRequestForm = changeRequestForm;
            _changeRequestService = changeRequestService;
            _userService = userService;
        }

        public ChangeRequestPresenter(AdminRequestsForm adminRequestsForm, IChangeRequestService changeRequestService)
        {
            _adminRequestsForm = adminRequestsForm;
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
            _adminRequestsForm.UpdateChangeRequestsList(requests);
            return requests;
        }

        public void LoadRequests()
        {
            var requests = _changeRequestService.GetAllChanges();
            _adminRequestsForm.UpdateChangeRequestsList(requests);
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
