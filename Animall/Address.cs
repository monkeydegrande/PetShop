using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Animall
{
    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(DataType = "int", ElementName = "HouseNumber")]
        public int HouseNumber { get; set; }

        [XmlElement(DataType = "string", ElementName = "StreetName")]
        public string StreetName { get; set; }

        [XmlElement(DataType = "string", ElementName = "City")]
        public string City { get; set; }

        [XmlElement(DataType = "string", ElementName = "State")]
        public string State { get; set; }

        [XmlElement(DataType = "int", ElementName = "ZipCode")]
        public int ZipCode { get; set; }

        public Address() { }

        public Address(
            int houseNumber,
            string streetName,
            string city,
            string state,
            int zipCode)
        {
            HouseNumber = houseNumber;
            StreetName = streetName;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
