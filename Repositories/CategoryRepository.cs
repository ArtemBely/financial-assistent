using FinancialAssistent.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {

        private string connectionString;

        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCategory(string category)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["InsertNewCategory"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", category);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Category> FetchCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
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
    }
}
