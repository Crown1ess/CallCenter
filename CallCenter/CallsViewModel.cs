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

namespace CallCenter
{
    public class CallsViewModel : INotifyPropertyChanged
    {
        ComplexCommand complexCommand;
        CallProperties callProperties;
        public ObservableCollection<AboutCall> Calls { get; private set; }
        public string LoginFromForm { get; private set; }

        public CallsViewModel(string login)
        {
            complexCommand = new ComplexCommand();
            LoginFromForm = login;
            Calls = new ObservableCollection<AboutCall>(complexCommand.GetInformationAboutCalls().Where(l => l.Login.Equals(LoginFromForm)));//user.Login equals null, I should look for why
        }
        private RelayCommand jumpToProperties;
        public RelayCommand JumpToProperties
        {
            get
            {
                return jumpToProperties ??
                    (jumpToProperties = new RelayCommand(obj =>
                    {
                        callProperties = new CallProperties();
                        System.Windows.Application.Current.MainWindow.Close();
                        callProperties.Show();
                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string properties = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(properties));
        }
    }
}
