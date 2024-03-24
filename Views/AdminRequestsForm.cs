using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using FinancialAssistent.Utilities;

namespace FinancialAssistent.Views
{
    public partial class AdminRequestsForm : Form
    {

        private readonly ChangeRequestPresenter _presenter;
        private List<ChangeRequest> _changeRequests;

        //Index of the sorted column with statuses
        private const int StatusColumnIndex = 6;

        public AdminRequestsForm()
        {
            InitializeComponent();
            _presenter = new ChangeRequestPresenter(this, new ChangeRequestService());
        }


        private void AdminRequestsForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadRequests();
        }

        public void UpdateChangeRequestsList(List<ChangeRequest> changeRequests)
        {
            _changeRequests = changeRequests;
            listViewRequests.Items.Clear();

            if (listViewRequests.Columns.Count == 0)
            {
                listViewRequests.Columns.Add("ChangeRequestId", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("UserID", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("New First Name", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("New Last Name", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("New Email", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("New Date of Birth", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("New Phone Number", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("Status", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("Comment", -2, HorizontalAlignment.Left);
                listViewRequests.Columns.Add("Request Date", -2, HorizontalAlignment.Left);
            }

            foreach (var changeRequest in changeRequests)
            {
                var item = new ListViewItem($"{changeRequest.ChangeRequestId}")
                {
                    Tag = changeRequest
                };
                item.SubItems.Add($"{changeRequest.UserId}");
                item.SubItems.Add(changeRequest.NewFirstName);
                item.SubItems.Add(changeRequest.NewLastName);
                item.SubItems.Add(changeRequest.NewEmail);
                item.SubItems.Add(changeRequest.NewDateOfBirth.ToShortDateString());
                item.SubItems.Add(changeRequest.NewPhoneNumber);
                item.SubItems.Add(changeRequest.Status.ToString());
                item.SubItems.Add(changeRequest.Comment);
                item.SubItems.Add(changeRequest.RequestDate.ToShortDateString());
                listViewRequests.Items.Add(item);
            }

            listViewRequests.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRequests.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewRequests_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == StatusColumnIndex)
            {
                listViewRequests.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewRequests.Sorting);
                listViewRequests.Sort();
                listViewRequests.Sorting = listViewRequests.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
        }

        private int? GetSelectedRequestId()
        {
            if (listViewRequests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a change request.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            var selectedChangeRequest = listViewRequests.SelectedItems[0].Tag as ChangeRequest;
            if (selectedChangeRequest != null)
            {
                return selectedChangeRequest.ChangeRequestId;
            }
            else
            {
                MessageBox.Show("The selected item does not have a request associated with it.");
                return null;
            }
        }

        private void Processt_Request_Click(object sender, EventArgs e)
        {
            var requestId = GetSelectedRequestId();
            if (!requestId.HasValue)
            {
                return;
            }

            var selectedChangeRequest = (ChangeRequest)listViewRequests.SelectedItems[0].Tag;
            var changeRequestForm = new ChangeRequestForm(selectedChangeRequest, _changeRequests, false); 
            var result = changeRequestForm.ShowDialog();

            if (result == DialogResult.OK)
            {
            }
        }

    }
}
