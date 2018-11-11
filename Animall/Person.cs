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
        [XmlElement(DataType = "string", ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(DataType = "string", ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(DataType = "string", ElementName = "UserName")]
        public string UserName { get; set; }

        [XmlElement(DataType = "string", ElementName = "Password")]
        public string Password { get; set; }

        [XmlElement(DataType = "string", ElementName = "Email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "HomeAddress")]
        public Address HomeAddress { get; set; }

        [XmlElement(ElementName = "Seller")]
        public bool Seller { get; set; }

        /**CONSTRUCTORS**/
        public Person() { }

        public Person(string first, string last, Address address, int schoolID, string email, string userName, string password, bool seller)
        {
            FirstName = first;
            LastName = last;
            HomeAddress = address;
            UserName = userName;
            Password = password;
            Email = email;
            Seller = seller;
        }

        //Return name and ID of student
        public override string ToString()
        {
            return $"{FirstName}";
        }
    }
}
