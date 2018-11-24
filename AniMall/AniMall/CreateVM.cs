﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AniMall
{
    public class CreateVM : INotifyPropertyChanged
    {
        Thickness BThickTwo = new Thickness(2), BThickZero = new Thickness(0);

        public ObservableCollection<Person> People;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Add account types to ComboBox
        private List<string> accounts = new List<string>(new string[] { "", "Seller", "Buyer" });
        public List<string> Accounts
        {
            get { return accounts; }
        }

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


        private string fName;
        public string FName
        {
            get { return fName; }
            set
            {
                fName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FName"));
            }
        }

        private string lName;
        public string LName
        {
            get { return lName; }
            set
            {
                lName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LName"));
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

        private string sName;
        public string SName
        {
            get { return sName; }
            set
            {
                sName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SName"));
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

        //Add States to State Combobox
        private List<string> states = new List<string>(new string[] { "", "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA",
                "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH",
                "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY" });
        public List<string> States
        {
            get { return states; }
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

        //Add payment types to ComboBox
        private List<string> cards = new List<string>(new string[] { "", "Visa", "Mastercard", "Discover", "American Express" });
        public List<string> Cards
        {
            get { return cards; }
        }

        private string card;
        public string Card
        {
            get { return card; }
            set
            {
                card = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Card"));
            }
        }

        private string cNum;
        public string CNum
        {
            get { return cNum; }
            set
            {
                cNum = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CNum"));
            }
        }

        //Add Exp Month to ComboBox
        private List<string> expMos = new List<string>(new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
        public List<string> ExpMos
        {
            get { return expMos; }
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

        //Add Exp Month to ComboBox
        private List<string> expYrs = new List<string>(new string[] { "", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
        public List<string> ExpYrs
        {
            get { return expYrs; }
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

//CONSTRUCTOR
        public CreateVM()
        {

        }

        //FUNCTIONS
        //Clear error info
        //private void ChangedText(TextBox tb)
        //{
        //    if (tb != null)
        //    {
        //        if (tb.Name == MW.Create.UserNameTextBox.Name)
        //        {
        //            MW.Create.UserNameTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.FirstNameTextBox.Name)
        //        {
        //            MW.Create.FirstNameTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.LastNameTextBox.Name)
        //        {
        //            MW.Create.LastNameTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.HouseNumberTextBox.Name)
        //        {
        //            MW.Create.HouseNumberTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.StreetNameTextBox.Name)
        //        {
        //            MW.Create.StreetNameTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.CityTextBox.Name)
        //        {
        //            MW.Create.CityTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.ZipTextBox.Name)
        //        {
        //            MW.Create.ZipTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.EmailAddressTextBox.Name)
        //        {
        //            MW.Create.EmailAddressTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.CardTextBox.Name)
        //        {
        //            MW.Create.CardTextBox.Background = Brushes.White;
        //        }
        //        else if (tb.Name == MW.Create.CVVTextBox.Name)
        //        {
        //            MW.Create.CVVTextBox.Background = Brushes.White;
        //        }
        //    }
        //}

        //Clear error info
        //private void ChangedPassword(PasswordBox pb)
        //{
        //    if (pb != null)
        //    {
        //        MW.Create.PasswordTextBox.Background = Brushes.White;
        //    }
        //}

        //Clear error info
        //private void ChangedSelection(ComboBox cb)
        //{
        //    if (cb != null)
        //    {
        //        if (cb.Name == MW.Create.AccountComboBox.Name)
        //        {
        //            MW.Create.AccountBorder.BorderThickness = BThickZero;
        //        }
        //        else if (cb.Name == MW.Create.StateComboBox.Name)
        //        {
        //            MW.Create.StateBorder.BorderThickness = BThickZero;
        //        }
        //        else if (cb.Name == MW.Create.PaymentComboBox.Name)
        //        {
        //            MW.Create.PaymentBorder.BorderThickness = BThickZero;
        //        }
        //        else if (cb.Name == MW.Create.ExpMoComboBox.Name)
        //        {
        //            MW.Create.ExpMoBorder.BorderThickness = BThickZero;
        //        }
        //        else if (cb.Name == MW.Create.ExpYrComboBox.Name)
        //        {
        //            MW.Create.ExpYrBorder.BorderThickness = BThickZero;
        //        }
        //    }
        //}

            //Validate all entries 
        private bool ValidateEntries()
        {
            //Regex patterns for input validation
            string UNameRegex = @"^.{4,10}$";
            string NameRegex = @"^[a-zA-Z]+[']?[a-zA-Z]*$";
            string PasswordRegex = @".{8,20}";
            string EmailRegex = @"^([\w-\.]+)@((\[\d{1,3}\.\d{1,3}\.\d{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|\d{1,3})(\]?)$";
            string NumberRegex = @"^\d+$";
            string CityRegex = @"^[a-zA-Z]+['.']?[' ']?\s?[a-zA-Z]*$";
            string ZipRegex = @"^\d{5}$";
            string CardRegex = @"^\d{16}$";
            string CVVRegex = @"^\d{3}$";

            //Returned boolean values declaring if each entry is valid.
            bool AccountTypeValid,
                UserNameValid,
                PasswordValid,
                FirstNameValid,
                LastNameValid,
                EmailValid,
                HouseNumberValid,
                StreetNameValid,
                CityValid,
                StateValid,
                ZipValid,
                PaymentTypeValid,
                CardNumberValid,
                ExpMoValid,
                ExpYrValid,
                CVVValid;

            ////State Validation
            //AccountTypeValid = MW.Create.AccountComboBox.SelectedIndex == 0 ? false : true;
            //MW.Create.AccountBorder.BorderThickness = AccountTypeValid ? BThickZero : BThickTwo;

            ////User Name Validation
            //UserNameValid = Regex.IsMatch(MW.Create.UserNameTextBox.Text, UNameRegex) ? true : false;
            //MW.Create.UserNameTextBox.Background = UserNameValid ? Brushes.White : Brushes.Salmon;

            ////Password Validation
            //PasswordValid = Regex.IsMatch(MW.Create.PasswordTextBox.Password.ToString(), PasswordRegex) ? true : false;
            //MW.Create.PasswordTextBox.Background = PasswordValid ? Brushes.White : Brushes.Salmon;

            ////First Name Validation
            //FirstNameValid = Regex.IsMatch(MW.Create.FirstNameTextBox.Text, NameRegex) ? true : false;
            //MW.Create.FirstNameTextBox.Background = FirstNameValid ? Brushes.White : Brushes.Salmon;

            ////Last Name Validation
            //LastNameValid = Regex.IsMatch(MW.Create.LastNameTextBox.Text, NameRegex) ? true : false;
            //MW.Create.LastNameTextBox.Background = LastNameValid ? Brushes.White : Brushes.Salmon;

            ////House Number Validation
            //HouseNumberValid = Regex.IsMatch(MW.Create.HouseNumberTextBox.Text, NumberRegex) ? true : false;
            //MW.Create.HouseNumberTextBox.Background = HouseNumberValid ? Brushes.White : Brushes.Salmon;

            ////Steet Name Regex
            //StreetNameValid = string.IsNullOrWhiteSpace(MW.Create.StreetNameTextBox.Text) ? false : true;
            //MW.Create.StreetNameTextBox.Background = StreetNameValid ? Brushes.White : Brushes.Salmon;

            ////City Validation
            //CityValid = Regex.IsMatch(MW.Create.CityTextBox.Text, CityRegex) ? true : false;
            //MW.Create.CityTextBox.Background = CityValid ? Brushes.White : Brushes.Salmon;

            ////State Validation
            //StateValid = MW.Create.StateComboBox.SelectedIndex == 0 ? false : true;
            //MW.Create.StateBorder.BorderThickness = StateValid ? BThickZero : BThickTwo;

            ////Zip Validation
            //ZipValid = Regex.IsMatch(MW.Create.ZipTextBox.Text, ZipRegex) ? true : false;
            //MW.Create.ZipTextBox.Background = ZipValid ? Brushes.White : Brushes.Salmon;

            ////Email Validation
            //EmailValid = Regex.IsMatch(MW.Create.EmailAddressTextBox.Text, EmailRegex) ? true : false;
            //MW.Create.EmailAddressTextBox.Background = EmailValid ? Brushes.White : Brushes.Salmon;

            ////Payment Type Validation
            //PaymentTypeValid = MW.Create.PaymentComboBox.SelectedIndex == 0 ? false : true;
            //MW.Create.PaymentBorder.BorderThickness = PaymentTypeValid ? BThickZero : BThickTwo;

            ////Card Number Validation
            //CardNumberValid = Regex.IsMatch(MW.Create.CardTextBox.Text, CardRegex) ? true : false;
            //MW.Create.CardTextBox.Background = CardNumberValid ? Brushes.White : Brushes.Salmon;

            ////Expiration Month Validation
            //ExpMoValid = MW.Create.ExpMoComboBox.SelectedIndex == 0 ? false : true;
            //MW.Create.ExpMoBorder.BorderThickness = ExpMoValid ? BThickZero : BThickTwo;

            ////Expiration Year Validation
            //ExpYrValid = MW.Create.ExpYrComboBox.SelectedIndex == 0 ? false : true;
            //MW.Create.ExpYrBorder.BorderThickness = ExpYrValid ? BThickZero : BThickTwo;

            ////CVV Validation
            //CVVValid = Regex.IsMatch(MW.Create.CVVTextBox.Text, CVVRegex) ? true : false;
            //MW.Create.CVVTextBox.Background = CVVValid ? Brushes.White : Brushes.Salmon;

            //return (AccountTypeValid &&
            //    UserNameValid &&
            //    PasswordValid &&
            //    FirstNameValid &&
            //    LastNameValid &&
            //    EmailValid &&
            //    HouseNumberValid &&
            //    StreetNameValid &&
            //    CityValid &&
            //    StateValid &&
            //    ZipValid &&
            //    PaymentTypeValid &&
            //    CardNumberValid &&
            //    ExpMoValid &&
            //    ExpYrValid &&
            //    CVVValid);

            return true;
        }

        //Create Person from entered information
        private void PopulateInformation(Person per)
        {
            //per.AccountType = MW.Create.AccountComboBox.SelectedItem.ToString();
            //per.UserName = MW.Create.UserNameTextBox.Text;
            //per.Password = MW.Create.PasswordTextBox.Password;
            //per.FirstName = MW.Create.FirstNameTextBox.Text;
            //per.LastName = MW.Create.LastNameTextBox.Text;
            //Address address = new Address(
            //    Int32.Parse(MW.Create.HouseNumberTextBox.Text),
            //    MW.Create.StreetNameTextBox.Text,
            //    MW.Create.CityTextBox.Text,
            //    MW.Create.StateComboBox.SelectedValue.ToString(),
            //    Int32.Parse(MW.Create.ZipTextBox.Text));

            //per.HomeAddress = address;
            //per.Email = MW.Create.EmailAddressTextBox.Text;

            //CC cc = new CC(
            //    MW.Create.PaymentComboBox.SelectedItem.ToString(),
            //    long.Parse(MW.Create.CardTextBox.Text),
            //    Int32.Parse(MW.Create.ExpMoComboBox.SelectedItem.ToString()),
            //    Int32.Parse(MW.Create.ExpYrComboBox.SelectedItem.ToString()),
            //    Int32.Parse(MW.Create.CVVTextBox.Text));
        }

        //EVENT HANDLERS
        //Changes error information on ComboBoxes back to normal
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox cb = (sender as ComboBox);
            //if (cb != null)
            //{
            //    ChangedSelection(cb);
            //}
        }

        //Change error information on TextBoxes back to normal
        private void TextFieldChanged(object sender, TextChangedEventArgs e)
        {
            //TextBox tb = (sender as TextBox);
            //ChangedText(tb);
        }

        //Change error information on PasswordBox
        private void PasswordTextChanged(object sender, RoutedEventArgs e)
        {
            //PasswordBox pb = (sender as PasswordBox);
            //ChangedPassword(pb);
        }


        //DELEGATES AND BUTTON CLICKS

        //Clear all entries
        private void ClearClick(object obj)
        {
            //ChangedText(MW.Create.UserNameTextBox);
            //MW.Create.UserNameTextBox.Clear();

            //ChangedPassword(MW.Create.PasswordTextBox);
            //MW.Create.PasswordTextBox.Clear();

            //ChangedText(MW.Create.FirstNameTextBox);
            //MW.Create.FirstNameTextBox.Clear();

            //ChangedText(MW.Create.LastNameTextBox);
            //MW.Create.LastNameTextBox.Clear();

            //ChangedText(MW.Create.EmailAddressTextBox);
            //MW.Create.EmailAddressTextBox.Clear();

            //ChangedText(MW.Create.HouseNumberTextBox);
            //MW.Create.HouseNumberTextBox.Clear();

            //ChangedText(MW.Create.StreetNameTextBox);
            //MW.Create.StreetNameTextBox.Clear();

            //ChangedText(MW.Create.CityTextBox);
            //MW.Create.CityTextBox.Clear();

            //ChangedSelection(MW.Create.StateComboBox);
            //MW.Create.StateComboBox.SelectedIndex = 0;

            //ChangedText(MW.Create.ZipTextBox);
            //MW.Create.ZipTextBox.Clear();

            //ChangedSelection(MW.Create.AccountComboBox);
            //MW.Create.AccountComboBox.SelectedValue = 1;
        }

        public ICommand ClearCommand
        {
            get
            {
                if (_clearEvent == null)
                {
                    _clearEvent = new DelegateCommand(ClearClick);
                }

                return _clearEvent;
            }
        }

        DelegateCommand _clearEvent;


        //Add user
        private void AddUserClick(object obj)
        {
            if (ValidateEntries())
            {
                Person User = new Person(), temp = new Person();
                //User.AccountType = MW.Create.AccountComboBox.SelectedItem.ToString();
                temp = People.Where(x => x.UserName == User.UserName).FirstOrDefault();
                if (temp != null)
                {
                    MessageBox.Show("User exists already, please try a different user name.");
                }
                PopulateInformation(User);
                People.Add(User);
                //MW.Login.WriteXmlFile(People);
                MessageBox.Show("Account Created.");
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