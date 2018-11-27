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

        private int First = 0;

        Thickness BThickTwo = new Thickness(2), BThickZero = new Thickness(0);

        public Person User = new Person();
        private Address Address;
        private CC CC;

        public ObservableCollection<Person> People { get; set; }

        //Regex patterns for input validation

        string UNameRegex = @"^.{1,15}$";
        string PasswordRegex = @"^.{8,15}$";
        string NameRegex = @"^[a-zA-Z]+$";
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

        private string boundPassword;
        public string BoundPassword
        {
            get { return boundPassword; }
            set
            {
                boundPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BoundPassword"));
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

        private string payType;
        public string PayType
        {
            get { return payType; }
            set
            {
                payType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PayType"));
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
        #endregion

        #region Populate ComboBoxes
        //Add Account types to ComboBox
        private List<string> accounts = new List<string>(new string[] {"", "Buyer", "Seller" });
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
            People = mvm.People;
            MVM = mvm;
            accountType = "";
            userName = "";
            boundPassword = "";
            firstName = "";
            lastName = "";
            houseNumber = "";
            streetName = "";
            city = "";
            state = "";
            zip = "";
            email = "";
            payType = "";
            cardNumber = "";
            expMo = "";
            expYr = "";
            cVV = "";
        }

//METHODS
        //Add Person to People
        private void AddPerson()
        {
            Address = new Address(HouseNumber, StreetName, City, State, Zip);
            CC = new CC(PayType, CardNumber, ExpMo, ExpYr, CVV);
            User = new Person(AccountType,
            userName,
            boundPassword,
            firstName,
            lastName,
            Address,
            email,
            CC);
            People.Add(User);
            MVM.WriteXmlFile(People);
            ClearInfo();
            First = 0;
            MessageBox.Show("Account Created.");
        }

        //Trips Validation Error on items that were neglected
        private void TripValidation()
        {
            if (AccountType == "")
                AccountType = "";
            if(UserName == "")
                UserName = "";
            if (boundPassword == "")
                boundPassword = "";
            if (FirstName == "")
                FirstName = "";
            if (LastName == "")
                LastName = "";
            if (HouseNumber == "")
                HouseNumber = "";
            if (StreetName == "")
                StreetName = "";
            if (City == "")
                City = "";
            if (State == "")
                State = "";
            if (Zip == "")
                Zip = "";
            if (Email == "")
                Email = "";
            if (PayType == "")
                PayType = "";
            if (CardNumber == "")
                CardNumber = "";
            if (ExpMo == "")
                ExpMo = "";
            if (ExpYr == "")
                ExpYr = "";
            if (CVV == "")
                CVV = "";
        }

        private void ClearInfo()
        {
                accountType = "";
                userName = "";
                boundPassword = "";
                firstName = "";
                lastName = "";
                houseNumber = "";
                streetName = "";
                city = "";
                state = "";
                zip = "";
                email = "";
                payType = "";
                cardNumber = "";
                expMo = "";
                expYr = "";
                cVV = "";
        }

//COMMAND HANDLERS

        //Add User Click
        private void AddUserClick(object obj)
        {

            if (CreateControl._noOfErrorsOnScreen==0 &&
            accountType != "" &&
            userName != "" &&
            boundPassword != "" &&
            firstName != "" &&
            lastName != "" &&
            houseNumber != "" &&
            streetName != "" &&
            city != "" &&
            state != "" &&
            zip != "" &&
            email != "" &&
            payType != "" &&
            cardNumber != "" &&
            expMo != "" &&
            expYr != "" &&
            cVV != "")
            {
                Person temp = new Person();
                if (People.Count > 0)
                {
                    temp = People.Where(x => x.UserName == UserName).FirstOrDefault();
                    if (temp != null)
                    {
                        MessageBox.Show("User exists already, please try a different user name.");
                    }
                    else
                    {
                        AddPerson();
                        MVM.CurrentView = new CreateVM(MVM);
                    }
                }
                else
                {
                    AddPerson();
                    MVM.CurrentView = new CreateVM(MVM);
                }
            }
            else
            {
                MessageBox.Show("Invalid or incomplete information provided");
                TripValidation();
            }
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

        //Menu Exit Click
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

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

//VALIDATION
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
                if (First >= 15)
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

                    if (columnName == "BoundPassword")
                    {
                        if (!Regex.IsMatch(BoundPassword, PasswordRegex))
                            MessageBox.Show("Please enter a valid password");
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

                    if (columnName == "PayType")
                    {
                        if (string.IsNullOrEmpty(PayType))
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
                First++;
                return result;
            }
        }
        #endregion
    }
}
