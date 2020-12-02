using ActionWithDataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Linq;
using MySqlConnector;

namespace CallCenter
{
    public class CallsViewModel : INotifyPropertyChanged
    {
        CreateConnectionString createConnection;
        //CallProperties callProperties;
        public ObservableCollection<AboutCall> Calls { get; private set; }
        //public string LoginFromForm { get; private set; }
        private string login {get;set;}

        public CallsViewModel(string login)
        {
            createConnection = new CreateConnectionString();
            this.login = login;
            Calls = new ObservableCollection<AboutCall>();
            getInformationAboutCalls();
        }
        private void getInformationAboutCalls()
        {
            string sqlInquiryString = $"SELECT * FROM leads_and_calls WHERE login = '{login}'";
            using var connection = new MySqlConnection(createConnection.ConnectionString());
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Calls.Add(new AboutCall
                    {
                        ClientInformation = reader["client_phone_number"].ToString() + " " +
                        reader["create_lead_date"].ToString() + " " + reader["lead_stats"].ToString(),
                        CallMadeDate = reader["lead_call_date"].ToString(),
                        Login = reader["login"].ToString(),
                        CallTime = reader["call_time"].ToString()
                    });
                }
            }
        }
        //private RelayCommand jumpToProperties;
        //public RelayCommand JumpToProperties
        //{
        //    get
        //    {
        //        return jumpToProperties ??
        //            (jumpToProperties = new RelayCommand(obj =>
        //            {
        //                callProperties = new CallProperties();
        //                System.Windows.Application.Current.MainWindow.Close();
        //                callProperties.Show();
        //            }));
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string properties = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(properties));
        }
    }
}
