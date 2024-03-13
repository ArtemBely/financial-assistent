using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialAssistent.Presenters
{
    public class TransactionPresenter
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserProfileView _view;
        private TransactionForm transactionForm;

        public TransactionPresenter(IUserProfileView view, ITransactionService transactionService)
        {
            _view = view;
            _transactionService = transactionService;
        }

        public TransactionPresenter(TransactionForm transactionForm, ITransactionService transactionService)
        {
            this.transactionForm = transactionForm;
            _transactionService = transactionService;
        }

        public TransactionPresenter(EditTransactionForm editTransactionForm, ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public void InitializeChartData(int userId, string selectedMonth = null)
        {
            var dataPoints = _transactionService.GetTransactionData(userId, selectedMonth);

            if (dataPoints.Any())
            {
                _view.UpdateChart(dataPoints);
            }
            else
            {
                _view.ShowMessage("No data for this month was found.");
            }
        }

        public void LoadTransactions(int userId)
        {
            var transactions = _transactionService.GetTransactionsForUser(userId);
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"ID: {transaction.TransactionId}, UserID: {transaction.UserId}, Date: {transaction.Date}, Amount: {transaction.Amount}, CategoryID: {transaction.CategoryId}");
            }
            transactionForm.UpdateTransactionsList(transactions);
        }

        public void SaveTransaction(Transaction transaction)
        {
            _transactionService.AddTransaction(transaction);
        }

        public void RemoveTransaction(int transactionId)
        {
            _transactionService.RemoveTransaction(transactionId);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionService.UpdateTransaction(transaction);
        }


    }


}
