using Models;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ActionWithDataBase
{
    public class ComplexCommand
    {
        CreateConnectionString connectionString;
        private string sqlInquiryString;

        public ComplexCommand()
        {
            connectionString = new CreateConnectionString();
        }
        public ObservableCollection<AboutCall> GetInformationAboutCalls()
        {
            sqlInquiryString = "select * from leads_and_calls";
            ObservableCollection<AboutCall> calls = new ObservableCollection<AboutCall>();

            using var connection = new MySqlConnection(connectionString.AccessConnection());
            connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(sqlInquiryString, connection);
            using (MySqlDataReader mySqlReader = mySqlCommand.ExecuteReader())
            {
                while(mySqlReader.Read())
                {
                    calls.Add(new AboutCall
                    {
                        ClientPhoneNumber = mySqlReader["client_phone_number"].ToString(),
                        Login = mySqlReader["login"].ToString(),
                        LeadStats = mySqlReader["lead_stats"].ToString(),
                        LeadCallDate = mySqlReader["lead_call_date"].ToString(),
                        CallTime = mySqlReader["call_time"].ToString()
                    });
                }
            }
            return calls;
        }
        public ObservableCollection<User> GetUsers()
        {
            sqlInquiryString = "SELECT * FROM users_authorization";
            ObservableCollection<User> users = new ObservableCollection<User>();

            using var connection = new MySqlConnection(connectionString.AccessConnection());
            connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(sqlInquiryString, connection);
            using (MySqlDataReader mySqlReader = mySqlCommand.ExecuteReader())
            {
                while (mySqlReader.Read())
                {
                    users.Add(new User 
                    {
                        Login = mySqlReader["login"].ToString(),
                        Password = mySqlReader["password"].ToString()
                    });
                }
            }

            return users;

        }
    }
}
