using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    internal interface ITransactionRepository
    {
        List<Transaction> FetchTransactions(int userId);
        List<Transaction> FetchTransactionsForLastMonth(int userId);
        void AddTransaction(Transaction transaction);
        void RemoveTransaction(int transactionId);
        void UpdateTransaction(Transaction transaction);
    }
}
