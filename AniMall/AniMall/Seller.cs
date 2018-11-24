using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMall
{
    public class Seller : Person, INotifyPropertyChanged
    {
        private ObservableCollection<object> products = new ObservableCollection<object>();
        public ObservableCollection<object> Products
        {
            get { return products; }
            set
            {
                products = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CartCont"));
            }
        }

        //CONSTRUCTOR
        public Seller()
        {

        }

        public Seller(string accountType, string userName, string password, string first, string last, Address address, int schoolID, string email, CC cc)
        {
            AccountType = accountType;
            UserName = userName;
            Password = password;
            FirstName = first;
            LastName = last;
            HomeAddress = address;
            Email = email;
            UserCreditCard = cc;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
