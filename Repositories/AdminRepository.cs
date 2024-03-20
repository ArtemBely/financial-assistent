﻿using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private string connectionString;

        public AdminRepository(string connectionString)
        {
            this.connectionString = connectionString;

        }

        public List<User> FetchUsers()
        {
            var users = new List<User>();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var query = System.Configuration.ConfigurationManager.AppSettings["FetchAllCustomersQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    FirstName = Convert.ToString(reader["FirstName"]),
                                    LastName = Convert.ToString(reader["LastName"]),
                                    Email = Convert.ToString(reader["Email"]),
                                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                    PhoneNumber = Convert.ToString(reader["PhoneNumber"]),
                                    RoleId = Convert.ToInt32(reader["RoleId"])
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
            return users;
        }
    }
}