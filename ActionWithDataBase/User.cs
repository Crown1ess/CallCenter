using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ActionWithDataBase
{
    public class User
    {
        private string login;
        private string password;

        public string Login
        {
            get { return login; }
            set { this.login = value;}
        }
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }
    }
}
