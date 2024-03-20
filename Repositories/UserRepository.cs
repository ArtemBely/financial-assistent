using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    // Repositories/UserRepository.cs
    public class UserRepository : IUserRepository
    {

        private string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserRepository()
        {
        }

        public void AddUser(User user)
        {
        }

        public bool VerifyUserCredentials(string email, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["FetchLoggedCustomer"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var user = new User
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                RoleId = reader.GetInt32(reader.GetOrdinal("RoleId"))
                            };

                            return user;
                        }
                    }
                }
            }

            return null;
        }

    }

}
