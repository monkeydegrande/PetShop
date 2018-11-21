using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AniMall
{
    public class LoginVM : INotifyPropertyChanged
    {
        Person User;
        MainWindowVM MVM;
        MainWindow MW;
        ObservableCollection<Person> People;
        public LoginVM(MainWindowVM mvm)
        {
            MW = mvm.MW;
            MVM = mvm;
            User = MVM.User;
            People = MVM.People;
        }

        //EVENT HANDLERS



        //DELEGATES AND BUTTONCLICKS

        //Login
        private void LoginClick(object obj)
        {
            if (MW.LoginValidateEntries())
            {
                Person loginTemp = People.FirstOrDefault(user => user.UserName == MW.Login.userName.Text);

                if (loginTemp != null && loginTemp.Password == MW.Login.pwBox.Password)
                {
                    MW.Login.Visibility = Visibility.Hidden;
                    if (loginTemp.AccountType == "Seller")
                    {
                        MW.Seller.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error: Sign In");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error: Sign In");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginEvent == null)
                {
                    _loginEvent = new DelegateCommand(LoginClick);
                }

                return _loginEvent;
            }
        }

        DelegateCommand _loginEvent;

        //Create user
        private void CreateClick(object obj)
        {
            MW.Login.Visibility = Visibility.Hidden;
            MW.Create.Visibility = Visibility.Visible;
        }

        public ICommand CreateUserCommand
        {
            get
            {
                if (_createUserEvent == null)
                {
                    _createUserEvent = new DelegateCommand(CreateClick);
                }

                return _createUserEvent;
            }
        }

        DelegateCommand _createUserEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
