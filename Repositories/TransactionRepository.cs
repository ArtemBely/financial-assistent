﻿using FinancialAssistent.Models;
using System.Data.SQLite;

namespace FinancialAssistent.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["InsertNewTransaction"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", transaction.UserId);
                    command.Parameters.AddWithValue("@Date", transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@CategoryId", transaction.CategoryId);

                    command.ExecuteNonQuery();
                }

            }
        }

        public void UpdateTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["UpdateTransactionQuery"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@CategoryId", transaction.CategoryId);
                    command.Parameters.AddWithValue("@TransactionId", transaction.TransactionId);

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Transaction> FetchTransactions(int userId)
        {
            var transactions = new List<Transaction>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var query = System.Configuration.ConfigurationManager.AppSettings["FetchAllTransactionsQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new Transaction
                                {
                                    TransactionId = Convert.ToInt32(reader["TransactionId"]),
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Amount = (float)Convert.ToDecimal(reader["Amount"]),
                                    CategoryId = Convert.ToInt32(reader["CategoryId"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return transactions;
        }

        public void RemoveTransaction(int transactionId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = System.Configuration.ConfigurationManager.AppSettings["DeleteOneTransactionsQuery"];

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionId", transactionId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Transaction> FetchTransactionsForLastMonth(int userId)
        {
            var transactions = new List<Transaction>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var query = System.Configuration.ConfigurationManager.AppSettings["FetchTransactionsByUserPerMonthQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new Transaction
                                {
                                    TransactionId = Convert.ToInt32(reader["TransactionId"]),
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Amount = (float)Convert.ToDecimal(reader["Amount"]),
                                    CategoryId = Convert.ToInt32(reader["CategoryId"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return transactions;
        }

    }

}
