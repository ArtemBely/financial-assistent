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

        List<Transaction> GetRecentTransactionsForUser(int userId);

        void AddTransaction(Transaction transaction);

        void RemoveTransaction(int transactionId);

        void UpdateTransaction(Transaction transaction);

    }
}
