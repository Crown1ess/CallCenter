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

        public string ConnectionString()
        {
            server = "";
            userID = "";
            database = "";
            password = "";

            string connectionString = $"server = {server}; uid = {userID}; database = {database}; password = {password}";
            return connectionString;
        }

    }
}
