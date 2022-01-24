namespace FlowerShop.ApplicationServices.Components.FlowersRecords
{
    using FlowerShop.ApplicationServices.Components.Flowers;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "notowania")]
    public class FlowerRates
    {
        [XmlElement(ElementName = "data_wygenerowania")]
        public string GeneratedDate { get; set; }

        [XmlElement(ElementName = "kurs_euro")]
        public string PlnEurRate { get; set; }

        [XmlArray("kategorie")]
        [XmlArrayItem("kategoria")]
        public List<TypeOfFlower> FlowerTypes = new List<TypeOfFlower>();
    }    
}