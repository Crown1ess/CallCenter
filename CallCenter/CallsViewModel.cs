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
        ComplexCommand complexCommand = new ComplexCommand();
        public ObservableCollection<AboutCall> Calls { get; private set; }// all the code do nothing and show nothing

        public CallsViewModel()
        {
            Calls = complexCommand.GetInformationAboutCalls();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string properties = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(properties));
        }
    }
}
