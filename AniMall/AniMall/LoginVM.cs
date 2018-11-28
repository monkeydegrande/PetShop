using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AniMall
{
    public class LoginVM : INotifyPropertyChanged
    {
        private Person user = new Person();
        public Person User
        {
            get { return user; }
            set
            {
                user = value;
                PropertyChanged(this, new PropertyChangedEventArgs("User"));
            }
        }
        private string uName;
        public string UName
        {
            get { return uName; }
            set
            {
                uName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UName"));
            }
        }

        private string pWord;
        public string PWord
        {
            get { return pWord; }
            set
            {
                pWord = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PWord"));
            }
        }


        public MainWindowVM MVM;
        public ObservableCollection<Person> People;

        //CONSTRUCTOR
        public LoginVM(){ }
        public LoginVM(MainWindowVM mvm)
        {
            MVM = mvm;
            People = MVM.People;
        }

//METHODS
        // Ensures username and password fields are not empty
        public bool ValidateEntries(PasswordBox pw)
        {
            if (string.IsNullOrWhiteSpace(UName) || string.IsNullOrWhiteSpace(pw.Password))
            { return false; }
            return true;
        }

//DELEGATES AND BUTTONCLICKS

        //Login
        private void LoginClick(object obj)
        {
            PasswordBox pw = obj as PasswordBox;
            //Ensure there were name and password entered
            if (ValidateEntries(pw))
            {
                //Ensure that obj is not null
                if (obj != null)
                {
                    pw = obj as PasswordBox;
                    PWord = pw.Password;
                }
                //If username matches an entry in people, check if password matches.
                User = People.FirstOrDefault(user => user.UserName == UName);

                //If entries match set User, and go to proper view
                if (User != null && User.Password == PWord)
                {
                    MVM.User = User;
                    if (User.AccountType == "Seller")
                    {
                        MVM.CurrentView = new SellerVM(MVM, User);
                    }
                    else
                    {
                        MVM.CurrentView = new BuyerVM(MVM, User);
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
            MVM.CurrentView = new CreateVM(MVM);
        }

        public ICommand CreateCommand
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


        //Exit Application
        private void ExitClick(object obj)
        {
            App.Current.Shutdown();
        }

        public ICommand ExitCommand
        {
            get
            {
                if (_exitEvent == null)
                {
                    _exitEvent = new DelegateCommand(ExitClick);
                }

                return _exitEvent;
            }
        }

        DelegateCommand _exitEvent;
    }
}
