using FinancialAssistent.Models;
using System.Data;
using System.Data.SQLite;

namespace FinancialAssistent.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {

        private string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddCategory(string category)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    var query = System.Configuration.ConfigurationManager.AppSettings["InsertNewCategory"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", category);
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    return false;
                }
                throw;
            }
        }


        public List<Category> FetchCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    var query = System.Configuration.ConfigurationManager.AppSettings["FetchAllCategoriesQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Category
                                {
                                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                    CategoryName = Convert.ToString(reader["CategoryName"])
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
            return categories;
        }

        public void RemoveCategory(string categoryName)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = System.Configuration.ConfigurationManager.AppSettings["DeleteOneCategoryQuery"];

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["UpdateCategoryQuery"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@CategoryName", DbType.String) { Value = category.CategoryName });
                    command.Parameters.Add(new SQLiteParameter("@CategoryId", DbType.Int32) { Value = category.CategoryId });

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
