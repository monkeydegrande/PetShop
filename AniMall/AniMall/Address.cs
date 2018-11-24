using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall 
{
    [XmlRoot(ElementName = "Address")]
    public class Address : INotifyPropertyChanged
    {
        [XmlIgnore]
        private string houseNumber;
        [XmlElement(DataType = "string", ElementName = "HouseNumber")]
        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {

                houseNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("HouseNumber"));
            }
        }

        [XmlIgnore]
        private string streetName;
        [XmlElement(DataType = "string", ElementName = "StreetName")]
        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StreetName"));
            }
        }

        [XmlIgnore]
        private string city;
        [XmlElement(DataType = "string", ElementName = "City")]
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("City"));
            }
        }

        [XmlIgnore]
        private string state;
        [XmlElement(DataType = "string", ElementName = "State")]
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        [XmlIgnore]
        private string zip;
        [XmlElement(DataType = "string", ElementName = "Zip")]
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Zip"));
            }
        }

        public Address() { }

        public Address(string hNumber, string sName, string cityName, string st, string zipCode)
        {
            houseNumber = hNumber;
            StreetName = sName;
            City = cityName;
            State = st;
            Zip = zipCode;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
