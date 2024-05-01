using FinancialAssistent.Models;
using System.Configuration;
using System.Data.SQLite;

namespace FinancialAssistent.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {

        private string _connectionString;

        public BudgetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBudget(Budget budget)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = ConfigurationManager.AppSettings["InsertNewBudget"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", budget.UserId);
                    command.Parameters.AddWithValue("@CategoryId", budget.CategoryId);
                    command.Parameters.AddWithValue("@Limit", budget.Limit);

                    command.ExecuteNonQuery();
                }

            }
        }

        public List<Budget> FindAllByUser(int userId)
        {
            var budgets = new List<Budget>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var query = ConfigurationManager.AppSettings["FindBudgetByUserQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                budgets.Add(new Budget
                                {
                                    BudgetId = Convert.ToInt32(reader["BudgetId"]),
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                    Limit = Convert.ToDecimal(reader["Limit"])
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
            return budgets;
        }


        public Budget FindByUserAndCategory(int userId, int categoryId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = ConfigurationManager.AppSettings["FindBudgetByUserAndCategoryQuery"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var budget = new Budget
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Limit = Convert.ToDecimal(reader["Limit"])
                            };

                            return budget;
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateBudget(Budget budget)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = ConfigurationManager.AppSettings["UpdateBudgetQuery"];

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Limit", budget.Limit);
                    command.Parameters.AddWithValue("@UserId", budget.UserId);
                    command.Parameters.AddWithValue("@CategoryId", budget.CategoryId);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
