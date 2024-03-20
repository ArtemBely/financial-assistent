using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public class UserService : IUserService
    {

        private readonly string _connectionString;
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _userRepository = new UserRepository(connectionString);
        }

        public UserService(UserRepository userRepository)
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (_connectionString == null)
            {
                throw new InvalidOperationException("Connection string doesn't exist.");
            }
            userRepository = new UserRepository(_connectionString);
        }

        public User AuthenticateUser(string email, string password)
        {
            string dbPath = "jasonbourne.db";
            string connectionString = $"Data Source={dbPath}";
            User user = null;

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM User WHERE Email = $email;";
                command.Parameters.AddWithValue("$email", email);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string passwordHash = reader["PasswordHash"].ToString();
                        bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, passwordHash);

                        if (isValidPassword)
                        {
                            user = new User
                            {
                                UserId = int.Parse(reader["UserId"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                PasswordHash = passwordHash,
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                PhoneNumber = reader["PhoneNumber"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void RegisterUser(User user)
        {
        }
    }
}
