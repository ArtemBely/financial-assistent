using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;

namespace FinancialAssistent.Views
{
    public partial class ChangeRequestForm : Form
    {
        private User _user;
        private ChangeRequest _changeRequest;
        private readonly ChangeRequestPresenter _presenter;
        private List<ChangeRequest> _changeRequests;
        public event EventHandler ChangeRequestUpdated;
        private bool _userEdition;

        public ChangeRequestForm(User user)
        {
            InitializeComponent();
            _userEdition = true;
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _presenter = new ChangeRequestPresenter(this, new ChangeRequestService(), new UserService());
            rejectBtn.Visible = false;
        }

        public ChangeRequestForm(ChangeRequest changeRequest, List<ChangeRequest> changeRequests, bool loadEnabled)
        {
            InitializeComponent();
            _userEdition = false;
            _changeRequest = changeRequest ?? throw new ArgumentNullException(nameof(changeRequest));
            _presenter = new ChangeRequestPresenter(this, new ChangeRequestService(), new UserService());
            _changeRequests = changeRequests;
            rejectBtn.Visible = true;
            statusNotificationLabel.Visible = true;
            textBoxRequestName.Enabled = false;
            textBoxRequestLastName.Enabled = false;
            textBoxRequestEmail.Enabled = false;
            textBoxRequestPhone.Enabled = false;
            timePickerRequestDateOfBirth.Enabled = false;
            statusNotificationLabel.Text = "Change Request";
            sendRequestBtn.Text = "Approve";
            LoadFormData(_changeRequest);
        }

        private void LoadFormData(ChangeRequest changeRequest)
        {
            textBoxRequestName.Text = changeRequest.NewFirstName;
            textBoxRequestLastName.Text = changeRequest.NewLastName;
            textBoxRequestEmail.Text = changeRequest.NewEmail;
            textBoxRequestPhone.Text = changeRequest.NewPhoneNumber;
            timePickerRequestDateOfBirth.Value = changeRequest.NewDateOfBirth;

        }

        private void ChangeRequestForm_Load(object sender, EventArgs e)
        {
            if (!_userEdition || _user == null)
                return;
            var pendingRequest = _presenter.FindPendingRequestByUserId(_user.UserId);
            if (pendingRequest != null)
            {
                textBoxRequestName.Text = pendingRequest.NewFirstName;
                textBoxRequestLastName.Text = pendingRequest.NewLastName;
                textBoxRequestEmail.Text = pendingRequest.NewEmail;
                textBoxRequestPhone.Text = pendingRequest.NewPhoneNumber;
                timePickerRequestDateOfBirth.Value = pendingRequest.NewDateOfBirth;

                statusNotificationLabel.Visible = true;
                textBoxRequestName.Enabled = false;
                textBoxRequestLastName.Enabled = false;
                textBoxRequestEmail.Enabled = false;
                textBoxRequestPhone.Enabled = false;
                timePickerRequestDateOfBirth.Enabled = false;
                sendRequestBtn.Enabled = false;
            }
            else
            {
                textBoxRequestName.Text = _user.FirstName;
                textBoxRequestLastName.Text = _user.LastName;
                textBoxRequestEmail.Text = _user.Email;
                textBoxRequestPhone.Text = _user.PhoneNumber;
                timePickerRequestDateOfBirth.Value = _user.DateOfBirth;
            }
        }



        private void RejectBtn_Click(object sender, EventArgs e)
        {
            SetStatus(ChangeRequestStatus.Rejected);
        }

        private void AddChangeRequestBtn_Click(object sender, EventArgs e)
        {
            if (_userEdition) SendRequest();
            else SetStatus(ChangeRequestStatus.Approved);
        }

        private void SetStatus(ChangeRequestStatus status)
        {
            var requestToUpdate = _changeRequests.FirstOrDefault(cr => cr.ChangeRequestId == _changeRequest.ChangeRequestId);
            if (requestToUpdate != null)
            {
                requestToUpdate.Status = status;
                if(status.Equals(ChangeRequestStatus.Approved)) UpdateUserDate();
            }
            _presenter.UpdateChangeRequest(_changeRequest);
            ChangeRequestUpdated?.Invoke(this, EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateUserDate()
        {
            User userToUpdate = new User
            {
                FirstName = _changeRequest.NewFirstName,
                LastName = _changeRequest.NewLastName,
                Email = _changeRequest.NewEmail,
                DateOfBirth = _changeRequest.NewDateOfBirth,
                PhoneNumber = _changeRequest.NewPhoneNumber,
                UserId = _changeRequest.UserId
            };
            _presenter.UpdateUserBasedOnChangeRequest(userToUpdate);
        }

        private void SendRequest()
        {
            if (string.IsNullOrWhiteSpace(textBoxRequestName.Text) ||
                string.IsNullOrWhiteSpace(textBoxRequestLastName.Text) ||
                string.IsNullOrWhiteSpace(textBoxRequestEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxRequestPhone.Text))
            {
                MessageBox.Show("Please ensure all fields are correctly filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeRequest = new ChangeRequest
                {
                    UserId = _user.UserId,
                    NewFirstName = textBoxRequestName.Text,
                    NewLastName = textBoxRequestLastName.Text,
                    NewEmail = textBoxRequestEmail.Text,
                    NewDateOfBirth = timePickerRequestDateOfBirth.Value,
                    NewPhoneNumber = textBoxRequestPhone.Text,
                    Status = ChangeRequestStatus.Pending,
                    RequestDate = DateTime.Now
                };

                _presenter.SaveChangeRequest(changeRequest);
                MessageBox.Show("Saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}
