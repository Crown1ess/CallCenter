using System;
using System.Collections.Generic;
using System.Text;

namespace ActionWithDataBase
{
    public class CreateConnectionString
    {
        private string server;
        private string dataBase;
        private string userId;
        private string password;
        private string host;
        public string ConnectionString;

        public CreateConnectionString()
        {
            server = "localhost";
            dataBase = "call_center";
            userId = "root";
            password = "";
            host = "3306";

            ConnectionString = @"server = {server}, database = {dataBase}, userId ={userId}, password ={password}, host ={host}";
        }

    }
}
