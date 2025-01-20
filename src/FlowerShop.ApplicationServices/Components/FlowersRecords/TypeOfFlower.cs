using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.FlowersRecords;

[XmlRoot(ElementName = "kategoria")]
public class TypeOfFlower
{
    [XmlElement(ElementName = "nazwa")]
    public required string Category { get; set; }

    [XmlArray("pozycje")]
    [XmlArrayItem("pozycja")]
    public List<Flower> Flowers = [];
}