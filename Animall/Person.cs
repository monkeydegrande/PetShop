using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "Person")]
    //Person class
    public class Person
    {
        //Properties
        [XmlElement(ElementName = "AccountType")]
        public string AccountType { get; set; }

        [XmlElement(DataType = "string", ElementName = "UserName")]
        public string UserName { get; set; }

        [XmlElement(DataType = "string", ElementName = "Password")]
        public string Password { get; set; }

        [XmlElement(DataType = "string", ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(DataType = "string", ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "HomeAddress")]
        public Address HomeAddress { get; set; }

        [XmlElement(DataType = "string", ElementName = "Email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "CreditCard")]
        public CC UserCreditCard { get; set; }

        /**CONSTRUCTORS**/
        public Person() { }

        public Person(string accountType, string userName, string password, string first, string last, Address address, int schoolID, string email, CC cc)
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

        //Return name and ID of student
        public override string ToString()
        {
            return $"{FirstName}";
        }
    }
}
