using System.Xml.Serialization;

namespace Fanex.Settlement.Converter.UnitTests.Services;

[XmlRoot("Results")]
public class XmlResults
{
    [XmlElement("Resource")]
    public List<XmlResource> Resources { get; set; }
}