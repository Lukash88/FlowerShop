using FlowerShop.ApplicationServices.Components.FlowersRecords;
using System.Xml;
using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.Flowers
{
    [XmlRoot(ElementName = "kategoria")]
    public class TypeOfFlower
    {
        [XmlElement(ElementName = "nazwa")]
        public string Category { get; set; }

        [XmlArray("pozycje")]
        [XmlArrayItem("pozycja")]
        public List<Flower> Flowers = new();
    }
}