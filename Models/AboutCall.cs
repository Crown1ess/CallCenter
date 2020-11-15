using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Models
{
    public class AboutCall : INotifyPropertyChanged
    {
        private string clientInformation;
        private string login;
        private string callMadeDate;
        private string callTime;

        public string ClientInformation
        {
            get { return clientInformation; }
            set 
            {
                clientInformation = value;
                OnPropertyChanged("ClientInformation");
            }

        }
        public string CallMadeDate
        {
            get { return callMadeDate; }
            set
            {
                callMadeDate = value;
                OnPropertyChanged("CallMadeDate");
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
