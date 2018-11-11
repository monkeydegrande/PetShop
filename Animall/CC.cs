using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AniMall
{
    [XmlRoot(ElementName = "CC")]
    public class CC
    {
        [XmlElement(DataType = "string", ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(DataType = "long", ElementName = "CardNumber")]
        public long CardNumber { get; set; }

        [XmlElement(DataType = "int", ElementName = "ExpMo")]
        public int ExpMo { get; set; }

        [XmlElement(DataType = "int", ElementName = "ExpYr")]
        public int ExpYr { get; set; }

        [XmlElement(DataType = "int", ElementName = "CVV")]
        public int CVV { get; set; }

        public CC() { }

        public CC(string type, long cardNumber, int expMo, int expYr, int cvv)
        {
            Type = type;
            CardNumber = cardNumber;
            ExpMo = ExpMo;
            ExpYr = ExpYr;
            CVV = cvv;
        }
    }
}
