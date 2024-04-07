using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinancialAssistent.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {

        private string connectionString;

        public BudgetRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddBudget(Budget budget)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["InsertNewBudget"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", budget.UserId);
                    command.Parameters.AddWithValue("@CategoryId", budget.CategoryId);
                    command.Parameters.AddWithValue("@Limit", budget.Limit);

                    command.ExecuteNonQuery();
                }

            }
        }

    }
}
