using System.Diagnostics.Eventing.Reader;
using ActionWithDataBase;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CallCenter
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        ComplexCommand complexCommand;
        private RelayCommand executeLogin;
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }



        public RelayCommand ExecuteLogin//i have to add checking login proccess
        {
            get
            {
                if (complexCommand.GetUsers().Any(l=>l.Login == login) && complexCommand.GetUsers().Any(p => p.Password == password))
                {
                    return executeLogin ??
                    (executeLogin = new RelayCommand(obj =>
                    {
                        MainWindow mainWindow = new MainWindow();
                        InformationWindow informationWindow = new InformationWindow();
                        mainWindow.Hide();
                        informationWindow.Show(); 
                    }));
                }
                else
                    throw new EventLogInvalidDataException();
                
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
