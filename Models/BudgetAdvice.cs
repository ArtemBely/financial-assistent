using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Models
{
    public class BudgetAdvice
    {
        public int CategoryId { get; set; }
        public decimal SuggestedLimit { get; set; }
    }

}
