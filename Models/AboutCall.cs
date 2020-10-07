using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Models
{
    public class AboutCall : INotifyPropertyChanged
    {
        private string clientPhoneNumber;
        private string login;
        private string leadStats;
        private string leadCallDate;
        private string callTime;

        public string ClientPhoneNumber
        {
            get { return clientPhoneNumber; }
            set 
            { 
                clientPhoneNumber = value;
                OnPropertyChanged("ClientPhoneNumber");
            }

        }
        public string Login
        {
            get { return login; }
            set 
            { 
                login = value;
                OnPropertyChanged("Login");
            }

        }
        public string LeadStats
        {
            get { return leadStats; }
            set
            {
                leadStats = value;
                OnPropertyChanged("LeadStats");
            }
        }
        public string LeadCallDate
        {
            get { return leadCallDate; }
            set 
            { 
                leadCallDate = value;
                OnPropertyChanged("LeadCallDate");
            }
        }
        public string CallTime
        {
            get { return callTime; }
            set
            {
                callTime = value;
                OnPropertyChanged("CallTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
