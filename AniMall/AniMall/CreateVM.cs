using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace AniMall
{
    public class CreateVM : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Properties

        MainWindowVM MVM;
        private bool first = true;

        Thickness BThickTwo = new Thickness(2), BThickZero = new Thickness(0);

        public Person User = new Person();

        public ObservableCollection<Person> People { get; set; }

        //Regex patterns for input validation

        string UNameRegex = @"^.{4,15}$";
        string NameRegex = @"^[a-zA-Z]+$";
        string PasswordRegex = @".{8,15}";
        string EmailRegex = @"^([\w-\.]+)@((\[\d{1,3}\.\d{1,3}\.\d{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|\d{1,3})(\]?)$";
        string NumberRegex = @"^\d+$";
        string CityRegex = @"^[a-zA-Z]+['.']?[' ']?\s?[a-zA-Z]*$";
        string ZipRegex = @"^\d{5}$";
        string CardRegex = @"^\d{16}$";
        string CVVRegex = @"^\d{3}$";

        private string accountType;
        public string AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AccountType"));
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        private string houseNumber;
        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("HouseNumber"));
            }
        }

        private string streetName;
        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StreetName"));
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("City"));
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        private string zip;
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Zip"));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }


        private string cCtype;
        public string CCType
        {
            get { return cCtype; }
            set
            {
                cCtype = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CCType"));
            }
        }

        private string cardNumber;
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                cardNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CardNumber"));
            }
        }

        private string expMo;
        public string ExpMo
        {
            get { return expMo; }
            set
            {
                expMo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpMo"));
            }
        }

        private string expYr;
        public string ExpYr
        {
            get { return expYr; }
            set
            {
                expYr = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpYr"));
            }
        }

        private string cVV;
        public string CVV
        {
            get { return cVV; }
            set
            {
                cVV = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CVV"));
            }
        }

        public ObservableCollection<Animal> CartCont { get; set; }

        //Add Account types to ComboBox
        private List<string> accounts = new List<string>(new string[] { "Buyer", "Seller" });
        public List<string> Accounts
        {
            get { return accounts; }
        }

        //Add States to State Combobox
        private List<string> states = new List<string>(new string[] { "", "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA",
                "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH",
                "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY" });
        public List<string> States
        {
            get { return states; }
        }

        //Add payment types to ComboBox
        private List<string> cards = new List<string>(new string[] { "", "Visa", "Mastercard", "Discover", "American Express" });
        public List<string> Cards
        {
            get { return cards; }
        }

        //Add Exp Month to ComboBox
        private List<string> expMos = new List<string>(new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
        public List<string> ExpMos
        {
            get { return expMos; }
        }

        //Add Exp Month to ComboBox
        private List<string> expYrs = new List<string>(new string[] { "", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
        public List<string> ExpYrs
        {
            get { return expYrs; }
        }
        #endregion

//CONSTRUCTOR
        public CreateVM(MainWindowVM mvm)
        {
            MVM = mvm;
            UserName = "";
            Password = "";
            FirstName = "";
            LastName = "";
            HouseNumber = "";
            StreetName = "";
            City = "";
            State = "";
            Zip = "";
            Email = "";
            CCType = "";
            CardNumber = "";
            ExpMo = "";
            ExpYr = "";
            CVV = "";
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void AddUserClick(object obj)
        {
            Person temp = People.Where(x => x.UserName == User.UserName).FirstOrDefault();
            if (temp != null)
            {
                MessageBox.Show("User exists already, please try a different user name.");
            }
            People.Add(User);
            MVM.WriteXmlFile(People);
            MessageBox.Show("Account Created.");
        }

        public ICommand AddUserCommand
        {
            get
            {
                if (_addEvent == null)
                {
                    _addEvent = new DelegateCommand(AddUserClick);
                }

                return _addEvent;
            }
        }

        DelegateCommand _addEvent;

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
        #region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (!first)
                {
                    //Account Info Validation
                    if (columnName == "AccountType")
                    {
                        if (string.IsNullOrEmpty(AccountType))
                            result = "Please pick an account type";
                    }

                    if (columnName == "UserName")
                    {
                        if (!Regex.IsMatch(UserName, UNameRegex))
                            result = "Please enter a user name";
                    }

                    if (columnName == "Password")
                    {
                        if (!Regex.IsMatch(Password, PasswordRegex))
                            result = "Please enter a password";
                    }

                    //User Info Validation
                    if (columnName == "FirstName")
                    {
                        if (!Regex.IsMatch(FirstName, NameRegex))
                            result = "Please enter a first name";
                    }

                    if (columnName == "LastName")
                    {
                        if (!Regex.IsMatch(LastName, NameRegex))
                            result = "Please enter a last name";
                    }

                    if (columnName == "HouseNumber")
                    {
                        if (!Regex.IsMatch(HouseNumber, NumberRegex))
                            result = "Please enter a valid house number";
                    }

                    if (columnName == "StreetName")
                    {
                        if (!Regex.IsMatch(StreetName, NameRegex))
                            result = "Please enter a valid street name";
                    }

                    if (columnName == "City")
                    {
                        if (!Regex.IsMatch(City, CityRegex))
                            result = "Please enter a valid city";
                    }

                    if (columnName == "Zip")
                    {
                        if (!Regex.IsMatch(Zip, ZipRegex))
                            result = "Please enter a valid zip code";
                    }

                    if (columnName == "State")
                    {
                        if (string.IsNullOrEmpty(State))
                            result = "Please pick a state";
                    }

                    if (columnName == "Email")
                    {
                        if (!Regex.IsMatch(Email, EmailRegex))
                            result = "Please enter a valid email address";
                    }

                    if (columnName == "Type")
                    {
                        if (string.IsNullOrEmpty(CCType))
                            result = "Please pick a type of payment";
                    }

                    if (columnName == "CardNumber")
                    {
                        if (!Regex.IsMatch(CardNumber, CardRegex))
                            result = "Please enter a valid card number";
                    }

                    if (columnName == "ExpMo")
                    {
                        if (string.IsNullOrEmpty(ExpMo))
                            result = "Please pick an expiration month";
                    }

                    if (columnName == "ExpYr")
                    {
                        if (string.IsNullOrEmpty(ExpYr))
                            result = "Please pick an expiration year";
                    }

                    if (columnName == "CVV")
                    {
                        if (!Regex.IsMatch(CVV, CVVRegex))
                            result = "Please enter a valid CVV";
                    }
                }
                first = false;
                return result;
            }
        }
        #endregion


        DelegateCommand _exitEvent;
    }
}
