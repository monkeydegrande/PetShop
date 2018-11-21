using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "Animal")]
    public class Animal
    {
        [XmlElement(DataType = "string", ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(DataType = "string", ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(DataType = "double", ElementName = "Price")]
        public double Price { get; set; }

        [XmlElement(DataType = "int", ElementName = "Stock")]
        public int Stock { get; set; }

        [XmlElement(DataType = "string", ElementName = "ImagePath")]
        public string ImagePath { get; set; }

        [XmlElement(DataType = "int", ElementName = "PurchAmt")]
        public int PurchAmt { get; set; }

        public Animal() { }

        public Animal(string name, string description, double price, int stock, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ImagePath = imagePath;
        }
    }
}
