using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Models
{
    public class TransactionPrediction
    {
        [ColumnName("Score")]
        public float Amount { get; set; }
    }

}
