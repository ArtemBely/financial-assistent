using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialAssistent.Views
{
    public partial class ChangeRequestForm : Form
    {
        private User _user;
        private readonly ChangeRequestPresenter _presenter;


        public ChangeRequestForm(User user)
        {
            InitializeComponent();
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _presenter = new ChangeRequestPresenter(this, new ChangeRequestService());
        }

        private void ChangeRequestForm_Load(object sender, EventArgs e)
        {
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
                //statusNotificationLabel.Visible = false;
                textBoxRequestName.Text = _user.FirstName;
                textBoxRequestLastName.Text = _user.LastName;
                textBoxRequestEmail.Text = _user.Email;
                textBoxRequestPhone.Text = _user.PhoneNumber;
                timePickerRequestDateOfBirth.Value = _user.DateOfBirth;
            }
        }


        private void AddChangeRequestBtn_Click(object sender, EventArgs e)
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
