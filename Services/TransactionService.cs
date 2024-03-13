using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string _connectionString;

        private TransactionRepository repository;

        public TransactionService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repository = new TransactionRepository(_connectionString);
        }

        public List<Transaction> GetTransactionsForUser(int userId)
        {
            return repository.FetchTransactions(userId);

        }

        public List<DataPoint> GetTransactionData(int userId, string selectedMonth = null)
        {
            var dataPoints = new List<DataPoint>();
            string fetchTransactionsQuery;
            if (selectedMonth == null)
            {
                fetchTransactionsQuery = System.Configuration.ConfigurationManager.AppSettings["FetchTransactionsQuery"];
            }
            else
            {
                fetchTransactionsQuery = System.Configuration.ConfigurationManager.AppSettings["FetchTransactionsPerMonthQuery"];
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = fetchTransactionsQuery;
                    command.Parameters.AddWithValue("@UserId", userId);
                    if (selectedMonth != null)
                    {
                        command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            double totalAmount = Convert.ToDouble(reader["TotalAmount"]);
                            DataPoint point = new DataPoint
                            {
                                AxisLabel = categoryName,
                                YValues = new double[] { totalAmount },
                                LegendText = categoryName,
                                Label = totalAmount.ToString("C")
                            };
                            dataPoints.Add(point);
                        }
                    }
                }
            }

            return dataPoints;
        }

       public void AddTransaction(Transaction transaction)
       {
            repository.AddTransaction(transaction);
       }

        public void RemoveTransaction(int transactionId)
        {
            repository.RemoveTransaction(transactionId);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            repository.UpdateTransaction(transaction);
        }
    }


}
