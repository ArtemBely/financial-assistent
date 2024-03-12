using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
