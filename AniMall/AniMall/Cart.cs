using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "Cart")]
    public class Cart
    {
        [XmlIgnore]
        private ObservableCollection<Animal> cartCont;
        [XmlElement(ElementName = "CartCont")]
        public ObservableCollection<Animal> CartCont
        {
            get { return cartCont; }
            set
            {
                cartCont = value;
            }
        }

        [XmlIgnore]
        private double total;
        [XmlElement(ElementName = "Total")]
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
            }
        }

        [XmlIgnore]
        private int items;
        [XmlElement(ElementName = "Items")]
        public int Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }

        public Cart()
        {
            total = 0;
            cartCont = new ObservableCollection<Animal>();
        }
    }
}
