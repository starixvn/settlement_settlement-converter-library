using System.Xml.Serialization;

namespace Fanex.Settlement.XmlConverter.UnitTests;

[XmlRoot("Results")]
public class XmlResults
{
    [XmlElement("Resource")]
    public List<XmlResource> Resources { get; set; }
}