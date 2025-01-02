using System.Xml;
using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.FlowersRecords
{
    [XmlRoot(ElementName = "pozycja")]
    public class Flower
    {
        [XmlElement(ElementName = "nazwa")]
        public string Name { get; set; }

        [XmlElement(ElementName = "jednostka")]
        public string Unit { get; set; }

        [XmlElement(ElementName = "cena_pln")]
        public string PricePln { get; set; }

        [XmlElement(ElementName = "cena_euro")]
        public string PriceEuro { get; set; }
    }
}