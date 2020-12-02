using System.Diagnostics.Eventing.Reader;
using ActionWithDataBase;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MySqlConnector;
using System.Collections.Generic;

namespace CallCenter
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        CreateConnectionString createConnection;
        InformationWindow informationWindow;

        private RelayCommand executeLogin;
        
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        //execute login and transition to the new window
        public RelayCommand ExecuteLogin
        {
            get
            {
                return executeLogin ??
                    (executeLogin = new RelayCommand(obj =>
                    {
                        if (checkUser())
                        {
                            informationWindow = new InformationWindow(Login);
                            System.Windows.Application.Current.MainWindow.Close();
                            informationWindow.Show(); 

                        }else
                        {
                            MessageBox.Show("Your password or login is not correct :D","Display");
                        }
                        
                    }));

            }
        }

        public UsersViewModel()
        {
            createConnection = new CreateConnectionString();
        }

        private bool checkUser()
        {
            List<User> users = new List<User>(); 
            string sqlInquiryString = $"SELECT * FROM users_authorization where login = '{Login}'";
            using var connection = new MySqlConnection(createConnection.ConnectionString());
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);

            using(MySqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    users.Add(new User
                    {
                        Login = reader["login"].ToString(),
                        Password = reader["password"].ToString()
                    });
                }
            }

            if (users.Any(u => u.Password.Equals(Password)))
                return true;
            else
                return false; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
