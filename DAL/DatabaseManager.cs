using DAL.Models;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace DAL {
    public class DatabaseManager {
        public SqlConnection connection { get; set; }
        public DatabaseManager()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TravelCommand;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            connection.Open();
        }

        public void CreateTravelCommand(string Participant, string StartLocation, string EndLocation, DateTime StartTime, DateTime EndTime, string Transportation, string Status)
        {
            var participant = GetEmployeeId(Participant);
            var startLocation = GetLocationId(StartLocation);
            var endLocation = GetLocationId(EndLocation);

            String sql = $"INSERT INTO TravelCommand (DateCreated, Participant, StartLocation,EndLocation ,StartTime,EndTime,Transportation,Status) " +
                $"VALUES ('{DateTime.Now.ToString("s")}', '{participant.Trim()}', {startLocation}, {endLocation}, '{StartTime.ToString("s")}', '{EndTime.ToString("s")}', '{Transportation.Trim()}', '{Status.Trim()}');";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                var result = command.ExecuteNonQuery();
            }
        }

        public List<TravelCommand> GetTravelCommands()
        {
            var result = new List<TravelCommand>();
            String sql = $"select * from TravelCommand";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TravelCommand data = new TravelCommand(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2).Trim(),
                            reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetDateTime(5), reader.GetDateTime(6),
                            reader.GetString(7).Trim(), reader.GetString(8).Trim());
                        result.Add(data);
                    }
                }
            }

            return result;
        }

        public TravelCommand GetTravelCommandById(int id)
        {
            TravelCommand result = new TravelCommand();
            String sql = $"select * from TravelCommand where Id = {id}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TravelCommand data = new TravelCommand(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2).Trim(),
                            reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetDateTime(5), reader.GetDateTime(6),
                            reader.GetString(7).Trim(), reader.GetString(8).Trim());
                        result = data;
                    }
                }
            }

            return result;
        }

        public void UpdateTravelCommand(TravelCommand travelCommand)
        {
            var participant = GetEmployeeId(travelCommand.Participant);
            var startLocation = GetLocationId(travelCommand.StartLocation);
            var endLocation = GetLocationId(travelCommand.EndLocation);
            String sql = $"update TravelCommand set Participant = '{participant.Trim()}', StartLocation = {startLocation}, EndLocation = {endLocation}, StartTime = '{travelCommand.StartTime.ToString("s")}', EndTime = '{travelCommand.EndTime.ToString("s")}', Transportation = '{travelCommand.Transportation.Trim()}', Status = '{travelCommand.Status.Trim()}' where Id = {travelCommand.Id}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                var result = command.ExecuteNonQuery();
            }
        }

        public int DeleteTravelCommand(int id)
        {
            var result = 0;
            String sql = $"delete from TravelCommand where Id = {id}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                 result = command.ExecuteNonQuery();
            }

            return result;
        }

        public string GetEmployeeId(string name)
        {
            var text = name.Split(' ');
            var firstName = text[0];
            var lastName = text[1];

            String sql = $"select * from Employee where FirstName = '{firstName}' and LastName = '{lastName}'";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }

            return "";
        }

        public int GetLocationId(string name)
        {
            String sql = $"select * from City where Name = '{name}'";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }

            return 0;
        }
    }
}