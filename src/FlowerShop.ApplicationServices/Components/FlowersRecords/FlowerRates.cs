using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.FlowersRecords;

[XmlRoot(ElementName = "notowania")]
public class FlowerRates
{
    [XmlElement(ElementName = "data_wygenerowania")]
    public required string GeneratedDate { get; set; }

    [XmlElement(ElementName = "kurs_euro")]
    public required string PlnEurRate { get; set; }

    [XmlArray("kategorie")]
    [XmlArrayItem("kategoria")]
    public List<TypeOfFlower> FlowerTypes = [];
}