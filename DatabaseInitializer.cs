using Microsoft.Data.Sqlite;

namespace FinancialAssistent
{
    internal class DatabaseInitializer
    {
        private static string GetDatabasePath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["dbTitle"];
        }

        private static string GetConnectionString()
        {
            return $"Data Source={GetDatabasePath()}";
        }

        /// <summary>
        /// This method is only for first initialization of User schema in sqlite.
        /// </summary>
        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                """
            CREATE TABLE IF NOT EXISTS Users (
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

        /// <summary>
        /// This method is for adding custom user with hashed password. For testing purpose only.
        /// </summary>
        public static void AddTestUser()
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                """
            INSERT INTO Users (FirstName, LastName, Email, PasswordHash, DateOfBirth, PhoneNumber, RoleId) 
            VALUES ($firstName, $lastName, $email, $passwordHash, $dateOfBirth, $phoneNumber, $roleId);
            """;
                string password = "john";
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                command.Parameters.AddWithValue("$firstName", "John");
                command.Parameters.AddWithValue("$lastName", "Simon");
                command.Parameters.AddWithValue("$email", "simon@mail.com");
                command.Parameters.AddWithValue("$passwordHash", passwordHash);
                command.Parameters.AddWithValue("$dateOfBirth", "1992-01-01");
                command.Parameters.AddWithValue("$phoneNumber", "420987654");
                command.Parameters.AddWithValue("$roleId", 1);

                command.ExecuteNonQuery();
            }
        }

    }
}
