using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "Animal")]
    public class Animal : INotifyPropertyChanged
    {
        [XmlIgnore]
        private string name;
        [XmlElement(DataType = "string", ElementName = "Name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        [XmlIgnore]
        private string description;
        [XmlElement(DataType = "string", ElementName = "Description")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        [XmlIgnore]
        private double price;
        [XmlElement(DataType = "double", ElementName = "Price")]
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Price"));
            }
        }

        [XmlIgnore]
        private int stock;
        [XmlElement(DataType = "int", ElementName = "Stock")]
        public int Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Stock"));
            }
        }

        [XmlElement(DataType = "string", ElementName = "ImagePath")]
        public string ImagePath { get; set; }

        [XmlIgnore]
        public int PurchAmt { get; set; } //Used by cart to keep track of number wanted by customer

        public Animal() { }

        public Animal(string name, string description, double price, int stock, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ImagePath = imagePath;
        }

        public string DisplayPrice()
        {
            return "$" + Price;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
