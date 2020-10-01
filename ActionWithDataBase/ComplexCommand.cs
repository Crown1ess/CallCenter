using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ActionWithDataBase
{
    public class ComplexCommand
    {
        CreateConnectionString createConnectionString;
        private string commandString;
        private ObservableCollection<User> users;

        public ComplexCommand()
        {
            createConnectionString = new CreateConnectionString();
            commandString = "select * from users_authorization";
        }
        public ObservableCollection<User> GetUsers()
        {
            using (MySqlConnection connection = new MySqlConnection(createConnectionString.ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(commandString, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(
                        new User
                        {
                            Login = reader.GetString("login"),
                            Password = reader.GetString("password")
                        });
                }
            }
            return users;
        }
    }
}
