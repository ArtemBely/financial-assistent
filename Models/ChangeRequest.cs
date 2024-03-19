using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Models
{
    public class ChangeRequest
    {
        public int ChangeRequestId { get; set; }
        public int UserId { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string NewEmail { get; set; }
        public DateTime NewDateOfBirth { get; set; }
        public string NewPhoneNumber { get; set; }
        public ChangeRequestStatus Status { get; set; } 
        public string Comment { get; set; }
        public DateTime RequestDate { get; set; }

        public ChangeRequest()
        {
            Status = ChangeRequestStatus.Pending;
            RequestDate = DateTime.Now;
        }
    }
}
