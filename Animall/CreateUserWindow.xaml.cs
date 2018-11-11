using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AniMall
{
    public partial class CreateUserWindow : Window
    {
        Thickness BThickTwo = new Thickness(2), BThickZero = new Thickness(0);

        public ObservableCollection<Person> People = new ObservableCollection<Person>();

//CONSTRUCTORS
        public CreateUserWindow(ObservableCollection<Person> people)
        {
            People = people;
            InitializeComponent();
            PopulateControls();
        }

//FUNCTIONS
        //Clear error info
        private void ChangedText(TextBox tb)
        {
            if (tb != null)
            {
                if (tb.Name == UserNameTextBox.Name)
                {
                    UserNameTextBox.Background = Brushes.White;
                }
                else if (tb.Name == FirstNameTextBox.Name)
                {
                    FirstNameTextBox.Background = Brushes.White;
                }
                else if (tb.Name == LastNameTextBox.Name)
                {
                    LastNameTextBox.Background = Brushes.White;
                }
                else if (tb.Name == HouseNumberTextBox.Name)
                {
                    HouseNumberTextBox.Background = Brushes.White;
                }
                else if (tb.Name == StreetNameTextBox.Name)
                {
                    StreetNameTextBox.Background = Brushes.White;
                }
                else if (tb.Name == CityTextBox.Name)
                {
                    CityTextBox.Background = Brushes.White;
                }
                else if (tb.Name == ZipTextBox.Name)
                {
                    ZipTextBox.Background = Brushes.White;
                }
                else if (tb.Name == EmailAddressTextBox.Name)
                {
                    EmailAddressTextBox.Background = Brushes.White;
                }
                else if (tb.Name == CardTextBox.Name)
                {
                    CardTextBox.Background = Brushes.White;
                }
                else if (tb.Name == CVVTextBox.Name)
                {
                    CVVTextBox.Background = Brushes.White;
                }
            }
        }

        //Clear error info
        private void ChangedPassword(PasswordBox pb)
        {
            if (pb != null)
            {
                PasswordTextBox.Background = Brushes.White;
            }
        }

        //Clear error info
        private void ChangedSelection(ComboBox cb)
        {
            if (cb != null)
            {
                if (cb.Name == AccountComboBox.Name)
                {
                    AccountBorder.BorderThickness = BThickZero;
                }
                else if (cb.Name == StateComboBox.Name)
                {
                    StateBorder.BorderThickness = BThickZero;
                }
                else if (cb.Name == PaymentComboBox.Name)
                {
                    PaymentBorder.BorderThickness = BThickZero;
                }
                else if (cb.Name == ExpMoComboBox.Name)
                {
                    ExpMoBorder.BorderThickness = BThickZero;
                }
                else if (cb.Name == ExpYrComboBox.Name)
                {
                    ExpYrBorder.BorderThickness = BThickZero;
                }
            }
        }

        //Populate controls with appropriate information
        public void PopulateControls()
        {
            //Add account types to ComboBox
            List<string> Accounts = new List<string>(new string[] { "", "Seller", "Buyer" });
            foreach (string acct in Accounts)
            {
                AccountComboBox.Items.Add(acct);
            }

            //Add payment types to ComboBox
            List<string> payments = new List<string>(new string[] { "", "Visa", "Mastercard", "Discover", "American Express" });
            foreach (string payment in payments)
            {
                PaymentComboBox.Items.Add(payment);
            }

            //Add States to State Combobox
            List<string> States = new List<string>(new string[] { "", "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA",
                "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH",
                "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY" });
            foreach (var state in States)
            {
                StateComboBox.Items.Add(state);
            }

            //Add Exp Month to ComboBox
            List<string> ExpMos = new List<string>(new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            foreach (var expMo in ExpMos)
            {
                ExpMoComboBox.Items.Add(expMo);
            }

            //Add Exp Month to ComboBox
            List<string> ExpYrs = new List<string>(new string[] { "", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            foreach (var expYr in ExpYrs)
            {
                ExpYrComboBox.Items.Add(expYr);
            }
        }
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

            //State Validation
            AccountTypeValid = AccountComboBox.SelectedIndex == 0 ? false : true;
            AccountBorder.BorderThickness = AccountTypeValid ? BThickZero : BThickTwo;

            //User Name Validation
            UserNameValid = Regex.IsMatch(UserNameTextBox.Text, UNameRegex) ? true : false;
            UserNameTextBox.Background = UserNameValid ? Brushes.White : Brushes.Salmon;

            //Password Validation
            PasswordValid = Regex.IsMatch(PasswordTextBox.Password.ToString(), PasswordRegex) ? true : false;
            PasswordTextBox.Background = PasswordValid ? Brushes.White : Brushes.Salmon;

            //First Name Validation
            FirstNameValid = Regex.IsMatch(FirstNameTextBox.Text, NameRegex) ? true : false;
            FirstNameTextBox.Background = FirstNameValid ? Brushes.White : Brushes.Salmon;

            //Last Name Validation
            LastNameValid = Regex.IsMatch(LastNameTextBox.Text, NameRegex) ? true : false;
            LastNameTextBox.Background = LastNameValid ? Brushes.White : Brushes.Salmon;

            //House Number Validation
            HouseNumberValid = Regex.IsMatch(HouseNumberTextBox.Text, NumberRegex) ? true : false;
            HouseNumberTextBox.Background = HouseNumberValid ? Brushes.White : Brushes.Salmon;

            //Steet Name Regex
            StreetNameValid = string.IsNullOrWhiteSpace(StreetNameTextBox.Text) ? false : true;
            StreetNameTextBox.Background = StreetNameValid ? Brushes.White : Brushes.Salmon;

            //City Validation
            CityValid = Regex.IsMatch(CityTextBox.Text, CityRegex) ? true : false;
            CityTextBox.Background = CityValid ? Brushes.White : Brushes.Salmon;

            //State Validation
            StateValid = StateComboBox.SelectedIndex == 0 ? false : true;
            StateBorder.BorderThickness = StateValid ? BThickZero : BThickTwo;

            //Zip Validation
            ZipValid = Regex.IsMatch(ZipTextBox.Text, ZipRegex) ? true : false;
            ZipTextBox.Background = ZipValid ? Brushes.White : Brushes.Salmon;

            //Email Validation
            EmailValid = Regex.IsMatch(EmailAddressTextBox.Text, EmailRegex) ? true : false;
            EmailAddressTextBox.Background = EmailValid ? Brushes.White : Brushes.Salmon;

            //Payment Type Validation
            PaymentTypeValid = PaymentComboBox.SelectedIndex == 0 ? false : true;
            PaymentBorder.BorderThickness = PaymentTypeValid ? BThickZero : BThickTwo;

            //Card Number Validation
            CardNumberValid = Regex.IsMatch(CardTextBox.Text, CardRegex) ? true : false;
            CardTextBox.Background = CardNumberValid ? Brushes.White : Brushes.Salmon;

            //Expiration Month Validation
            ExpMoValid = ExpMoComboBox.SelectedIndex == 0 ? false : true;
            ExpMoBorder.BorderThickness = ExpMoValid ? BThickZero : BThickTwo;

            //Expiration Year Validation
            ExpYrValid = ExpYrComboBox.SelectedIndex == 0 ? false : true;
            ExpYrBorder.BorderThickness = ExpYrValid ? BThickZero : BThickTwo;

            //CVV Validation
            CVVValid = Regex.IsMatch(CVVTextBox.Text, CVVRegex) ? true : false;
            CVVTextBox.Background = CVVValid ? Brushes.White : Brushes.Salmon;

            return (AccountTypeValid &&
                UserNameValid &&
                PasswordValid &&
                FirstNameValid &&
                LastNameValid &&
                EmailValid &&
                HouseNumberValid &&
                StreetNameValid &&
                CityValid &&
                StateValid &&
                ZipValid &&
                PaymentTypeValid &&
                CardNumberValid &&
                ExpMoValid &&
                ExpYrValid &&
                CVVValid);
        }
       
        //Create Person from entered information
        private void PopulateInformation(Person per)
        {
            per.AccountType = AccountComboBox.SelectedItem.ToString();
            per.UserName = UserNameTextBox.Text;
            per.Password = PasswordTextBox.Password;
            per.FirstName = FirstNameTextBox.Text;
            per.LastName = LastNameTextBox.Text;
            Address address = new Address(
                Int32.Parse(HouseNumberTextBox.Text),
                StreetNameTextBox.Text,
                CityTextBox.Text,
                StateComboBox.SelectedValue.ToString(),
                Int32.Parse(ZipTextBox.Text));

            per.HomeAddress = address;
            per.Email = EmailAddressTextBox.Text;

            CC cc = new CC(
                PaymentComboBox.SelectedItem.ToString(),
                long.Parse(CardTextBox.Text),
                Int32.Parse(ExpMoComboBox.SelectedItem.ToString()),
                Int32.Parse(ExpYrComboBox.SelectedItem.ToString()),
                Int32.Parse(CVVTextBox.Text));
        }

//EVENT HANDLERS
        //Changes error information on ComboBoxes back to normal
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            if (cb != null)
            {
                ChangedSelection(cb);
            }
        }

        //Change error information on TextBoxes back to normal
        private void TextFieldChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            ChangedText(tb);
        }

        //Change error information on PasswordBox
        private void PasswordTextChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (sender as PasswordBox);
            ChangedPassword(pb);
        }

        //Clear all entries
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            ChangedText(UserNameTextBox);
            UserNameTextBox.Clear();

            ChangedPassword(PasswordTextBox);
            PasswordTextBox.Clear();

            ChangedText(FirstNameTextBox);
            FirstNameTextBox.Clear();

            ChangedText(LastNameTextBox);
            LastNameTextBox.Clear();

            ChangedText(EmailAddressTextBox);
            EmailAddressTextBox.Clear();

            ChangedText(HouseNumberTextBox);
            HouseNumberTextBox.Clear();

            ChangedText(StreetNameTextBox);
            StreetNameTextBox.Clear();

            ChangedText(CityTextBox);
            CityTextBox.Clear();

            ChangedSelection(StateComboBox);
            StateComboBox.SelectedIndex = 0;

            ChangedText(ZipTextBox);
            ZipTextBox.Clear();

            ChangedSelection(AccountComboBox);
            AccountComboBox.SelectedValue = 1;
        }

        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            if(ValidateEntries())
            {
                Person User = new Person(), temp = new Person();
                User.AccountType = AccountComboBox.SelectedItem.ToString();
                temp = People.Where(x => x.UserName == User.UserName).FirstOrDefault();
                if (temp != null)
                {
                    MessageBox.Show("User exists already, please try a different user name.");
                }
                PopulateInformation(User);
                People.Add(User);
                Login.WriteXmlFile(People);
                MessageBox.Show("Account Created.");
            }
        }

        //Exit Application
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
