using System.Diagnostics.Eventing.Reader;
using ActionWithDataBase;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CallCenter
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        ComplexCommand complexCommand;
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

        public RelayCommand ExecuteLogin
        {
            get
            {
                return executeLogin ??
                    (executeLogin = new RelayCommand(obj =>
                    {
                        if (complexCommand.GetUsers().Any(l => l.Login.Equals(login)) && complexCommand.GetUsers().Any(p => p.Password.Equals(password)))
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
            complexCommand = new ComplexCommand();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
