using Microsoft.ML.Data;

namespace FinancialAssistent.Models
{
    public class TransactionPrediction
    {
        [ColumnName("Score")]
        public float Amount { get; set; }
    }

}
