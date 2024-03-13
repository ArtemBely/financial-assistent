using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    internal interface ITransactionRepository
    {
        public List<Transaction> FetchTransactions(int userId);
        void AddTransaction(Transaction transaction);
        void RemoveTransaction(int transactionId);
        void UpdateTransaction(Transaction transaction);
    }
}
