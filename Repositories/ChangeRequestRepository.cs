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

        public List<ChangeRequest> GetAllChanges()
        {
            var changeRequests = new List<ChangeRequest>();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var query = System.Configuration.ConfigurationManager.AppSettings["FetchAllChangeRequestsQuery"];
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                changeRequests.Add(new ChangeRequest
                                {
                                    ChangeRequestId = Convert.ToInt32(reader["ChangeRequestId"]),
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    NewFirstName = reader["NewFirstName"].ToString(),
                                    NewLastName = reader["NewLastName"].ToString(),
                                    NewEmail = reader["NewEmail"].ToString(),
                                    NewDateOfBirth = Convert.ToDateTime(reader["NewDateOfBirth"]),
                                    NewPhoneNumber = reader["NewPhoneNumber"].ToString(),
                                    Status = (ChangeRequestStatus)Enum.Parse(typeof(ChangeRequestStatus), reader["Status"].ToString()),
                                    Comment = reader["Comment"].ToString(),
                                    RequestDate = Convert.ToDateTime(reader["RequestDate"])
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
            return changeRequests;
        }

        public void UpdateChangeRequest(ChangeRequest changeRequest)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var query = System.Configuration.ConfigurationManager.AppSettings["UpdateChangeRequestByIdQuery"];
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", changeRequest.Status.ToString());
                    command.Parameters.AddWithValue("@ChangeRequestId", changeRequest.ChangeRequestId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
