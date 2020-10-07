using System.Diagnostics.Eventing.Reader;
using ActionWithDataBase;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CallCenter
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        ComplexCommand complexCommand = new ComplexCommand();
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


        public RelayCommand ExecuteLogin
        {
            get
            {
                return executeLogin ??
                    (executeLogin = new RelayCommand(obj =>
                    {
                        if (complexCommand.GetUsers().Any(l => l.Login.Equals(login)) && complexCommand.GetUsers().Any(p => p.Password.Equals(password)))
                        {
                            InformationWindow informationWindow = new InformationWindow();
                            System.Windows.Application.Current.MainWindow.Close();
                            informationWindow.Show();
                        }
                        
                    }));

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
