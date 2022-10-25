using System.Xml.Serialization;

namespace Fanex.Settlement.XmlConverter.UnitTests;

public class XmlResource
{
    [XmlAttribute("Id")]
    public string ResourceId { get; set; }

    [XmlAttribute]
    public string HomeValue { get; set; }

    [XmlAttribute]
    public string AwayValue { get; set; }
}