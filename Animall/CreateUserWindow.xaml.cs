using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        public CreateUserWindow(ObservableCollection<Person> people)
        {
            People = people;
            InitializeComponent();
        }

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

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
