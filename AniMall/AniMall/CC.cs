using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "CC")]
    public class CC : INotifyPropertyChanged
    {
        [XmlIgnore]
        private string type;
        [XmlElement(DataType = "string", ElementName = "Type")]
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Type"));
            }
        }

        [XmlIgnore]
        private string cardNumber;
        [XmlElement(DataType = "string", ElementName = "CardNumber")]
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                cardNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CardNumber"));
            }
        }

        [XmlIgnore]
        private string expMo;
        [XmlElement(DataType = "string", ElementName = "ExpMo")]
        public string ExpMo
        {
            get { return expMo; }
            set
            {
                expMo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpMo"));
            }
        }

        [XmlIgnore]
        private string expYr;
        [XmlElement(DataType = "string", ElementName = "ExpYr")]
        public string ExpYr
        {
            get { return expYr; }
            set
            {
                expYr = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpYr"));
            }
        }

        [XmlIgnore]
        private string cVV;
        [XmlElement(DataType = "string", ElementName = "CVV")]
        public string CVV
        {
            get { return cVV; }
            set
            {
                cVV = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CVV"));
            }
        }

        public CC() { }

        public CC(string t, string cNumber, string eMo, string eYr, string c)
        {
            type = t;
            cardNumber = cNumber;
            expMo = eMo;
            expYr = eYr;
            cVV = c;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
