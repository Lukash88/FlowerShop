namespace FlowerShop.ApplicationServices.Components.Flowers
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "kategoria")]
    public class TypeOfFlower
    {
        [XmlElement(ElementName = "nazwa")]
        public string Category { get; set; }

        [XmlArray("pozycje")]
        [XmlArrayItem("pozycja")]
        public List<Flower> Flowers = new List<Flower>();
    }
}