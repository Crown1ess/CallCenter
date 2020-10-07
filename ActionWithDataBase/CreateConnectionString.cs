using System;
using System.Collections.Generic;
using System.Text;

namespace ActionWithDataBase
{
    public class CreateConnectionString
    {
        private string userID;
        private string database;
        private string server;
        private string password;

        public string AccessConnection()
        {
            server = "127.0.0.1";
            userID = "root";
            database = "call_center";
            password = "";

            string connectionString = $"server = {server}; uid = {userID}; database = {database}; password = {password}";
            return connectionString;
        }

    }
}
