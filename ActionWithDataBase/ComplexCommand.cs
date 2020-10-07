using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ActionWithDataBase
{
    public class ComplexCommand
    {
        CreateConnectionString connectionString;
        private string sqlInquiryString;
        public ComplexCommand()
        {
            connectionString = new CreateConnectionString();
            sqlInquiryString = "SELECT * FROM users_authorization";
        }

        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            using var connection = new MySqlConnection(connectionString.AccessConnection());

            connection.Open();

            var mySqlCommand = new MySqlCommand(sqlInquiryString, connection);


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
