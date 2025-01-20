using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.FlowersRecords;

[XmlRoot(ElementName = "pozycja")]
public class Flower
{
    [XmlElement(ElementName = "nazwa")]
    public required string Name { get; set; }

    [XmlElement(ElementName = "jednostka")]
    public required string Unit { get; set; }

    [XmlElement(ElementName = "cena_pln")]
    public required string PricePln { get; set; }

    [XmlElement(ElementName = "cena_euro")]
    public required string PriceEuro { get; set; }
}