using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace AniMall
{
    [XmlRoot(ElementName = "Person")]
    //Person class
    public class Person : INotifyPropertyChanged
    {
        #region Properties
        [XmlIgnore]
        private string accountType;
        [XmlElement(ElementName = "AccountType")]
        public string AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AccountType"));
            }
        }

        [XmlIgnore]
        private string userName;
        [XmlElement(DataType = "string", ElementName = "UserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        [XmlIgnore]
        private string password;
        [XmlElement(DataType = "string", ElementName = "Password")]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        [XmlIgnore]
        private string firstName;
        [XmlElement(DataType = "string", ElementName = "FirstName")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        [XmlIgnore]
        private string lastName;
        [XmlElement(DataType = "string", ElementName = "LastName")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        [XmlIgnore]
        private Address homeAddress; 
        [XmlElement(ElementName = "HomeAddress")]
        public Address HomeAddress
        {
            get { return homeAddress; }
            set
            {
                homeAddress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("HomeAddress"));
            }
        }
        [XmlIgnore]
        private string email;
        [XmlElement(DataType = "string", ElementName = "Email")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        [XmlIgnore]
        private CC creditCard;
        [XmlElement(ElementName = "CreditCard")]
        public CC CreditCard
        {
            get { return creditCard; }
            set
            {
                creditCard = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CreditCard"));
            }
        }

        [XmlIgnore]

        [XmlElement(ElementName = "CartCont")]
        public ObservableCollection<Animal> CartCont { get; set; }
        #endregion

        /**CONSTRUCTORS**/
        public Person() { }

        public Person(string aType, string uName, string pword, string first, string last, Address address, string emailAddy, CC cc)
        {
            accountType = aType;
            userName = uName;
            password = pword;
            firstName = first;
            lastName = last;
            HomeAddress = address;
            email = emailAddy;
            creditCard = cc;
        }


        //Return name and ID of student
        public override string ToString()
        {
            return $"{FirstName}";
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
