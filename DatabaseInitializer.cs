using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent
{
    internal class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            // Указываем путь к файлу базы данных. Если файл не существует, он будет создан.
            string dbPath = "jasonbourne.db"; // Этот файл будет создан в корневой папке проекта (или в bin/debug, когда вы запускаете его из Visual Studio)
            string connectionString = $"Data Source={dbPath}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                """
            CREATE TABLE IF NOT EXISTS User (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                DateOfBirth TEXT NOT NULL,
                PhoneNumber TEXT,
                RoleId INTEGER
            );
            """;
                command.ExecuteNonQuery();
            }
        }
        public static void AddTestUser()
        {
            string dbPath = "jasonbourne.db";
            string connectionString = $"Data Source={dbPath}";
            string password = "admin";
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password); // Хеширование пароля

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                """
        INSERT INTO User (FirstName, LastName, Email, PasswordHash, DateOfBirth, PhoneNumber, RoleId) VALUES ($firstName, $lastName, $email, $passwordHash, $dateOfBirth, $phoneNumber, $roleId);
        """;
                command.Parameters.AddWithValue("$firstName", "Alan");
                command.Parameters.AddWithValue("$lastName", "Smith");
                command.Parameters.AddWithValue("$email", "admin");
                command.Parameters.AddWithValue("$passwordHash", passwordHash); // Используем хешированный пароль
                command.Parameters.AddWithValue("$dateOfBirth", "1994-01-01");
                command.Parameters.AddWithValue("$phoneNumber", "420987654");
                command.Parameters.AddWithValue("roleId", 2);

                command.ExecuteNonQuery();
            }
        }

        public static void CheckTableExists()
        {
            string dbPath = "jasonbourne.db";
            string connectionString = $"Data Source={dbPath}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                """
        SELECT name FROM sqlite_master WHERE type='table' AND name='Users';
        """;

                var result = command.ExecuteScalar();
                if (result != null && result.ToString() == "Users")
                {
                    string firstName = GetFirstUserName(); // Это вызов метода, который нужно реализовать
                    MessageBox.Show($"Таблица Users существует. Имя первого пользователя: {firstName}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Таблица Users не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        public static void InitializeDatabase2(string dbPath)
        {
            // ...
            Console.WriteLine($"База данных создана по пути: {Path.GetFullPath(dbPath)}");
            // ...
        }


        public static string GetFirstUserName()
        {
            string dbPath = "jasonbourne.db";
            string connectionString = $"Data Source={dbPath}";
            string firstName = "";

            InitializeDatabase2(dbPath);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT PasswordHash FROM Users LIMIT 1;";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader.GetString(0); // Получаем имя из первого столбца первой строки
                    }
                }
            }

            return firstName;
        }

    }
}
