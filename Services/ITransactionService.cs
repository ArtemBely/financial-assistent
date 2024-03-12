using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Services
{
    public interface ITransactionService
    {
        List<DataPoint> GetTransactionData(int userId, string selectedMonth = null);

        List<Transaction> GetTransactionsForUser(int userId);

        void AddTransaction(Transaction transaction);

    }
}
