using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    internal class ChangeRequestRepository : IChangeRequestRepository
    {

        private string connectionString;

        public ChangeRequestRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void AddChangeRequest(ChangeRequest changeRequest)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["InsertNewChangeRequest"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", changeRequest.UserId);
                    command.Parameters.AddWithValue("@NewFirstName", changeRequest.NewFirstName);
                    command.Parameters.AddWithValue("@NewLastName", changeRequest.NewLastName);
                    command.Parameters.AddWithValue("@NewEmail", changeRequest.NewEmail);
                    command.Parameters.AddWithValue("@NewDateOfBirth", changeRequest.NewDateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@NewPhoneNumber", changeRequest.NewPhoneNumber);
                    command.Parameters.AddWithValue("@Status", changeRequest.Status.ToString());
                    command.Parameters.AddWithValue("@Comment", changeRequest.Comment);
                    command.Parameters.AddWithValue("@RequestDate", changeRequest.RequestDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public ChangeRequest FindPendingRequestByUserId(int userId)
        {
            ChangeRequest request = null;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var query = System.Configuration.ConfigurationManager.AppSettings["CheckUserChangeRequestStatus"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            request = new ChangeRequest
                            {
                                UserId = userId,
                                NewFirstName = reader["NewFirstName"].ToString(),
                                NewLastName = reader["NewLastName"].ToString(),
                                NewEmail = reader["NewEmail"].ToString(),
                                NewDateOfBirth = DateTime.Parse(reader["NewDateOfBirth"].ToString()),
                                NewPhoneNumber = reader["NewPhoneNumber"].ToString(),
                                Status = Enum.Parse<ChangeRequestStatus>(reader["Status"].ToString()),
                                Comment = reader["Comment"].ToString(),
                                RequestDate = DateTime.Parse(reader["RequestDate"].ToString()),
                            };
                        }
                    }
                }
            }
            return request;
        }


    }
}
