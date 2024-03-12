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
        private readonly IUserRepository _userRepository;
        private UserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
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

        public void RegisterUser(User user)
        {
            // Реализация регистрации пользователя
        }
    }
}
