using FinancialAssistent.Models;
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

        public ChangeRequestForm(User user)
        {
            InitializeComponent();
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        private void ChangeRequestForm_Load(object sender, EventArgs e)
        {
            textBoxRequestName.Text = _user.FirstName;
            textBoxRequestLastName.Text = _user.LastName;
            textBoxRequestEmail.Text = _user.Email;
            textBoxRequestPhone.Text = _user.PhoneNumber;
            timePickerRequestDateOfBirth.Value = _user.DateOfBirth;
        }
    }

}
