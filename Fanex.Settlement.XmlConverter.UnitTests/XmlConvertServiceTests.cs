using Xunit;

namespace Fanex.Settlement.XmlConverter.UnitTests;

public class XmlConvertServiceTests
{
    private XmlConvertService service;

    public XmlConvertServiceTests()
    {
        service = new XmlConvertServiceImp();
    }

    [Fact]
    public void Serialize_FromNoResults_ReturnsOnlyResultElement()
    {
        // Arrange
        var xmlResults = new XmlResults
        {
            Resources = new List<XmlResource>()
        };

        // Act
        var xml = service.Serialize(xmlResults);

        // Assert
        Assert.Equal("<Results />", xml);
    }

    [Fact]
    public void Serialize_FromResults_ReturnsHasResourceElement()
    {
        // Arrange
        var results = new List<XmlResource>
            {
                new XmlResource()
            };

        var xmlResults = new XmlResults
        {
            Resources = results
        };
        // Act
        var xml = service.Serialize(xmlResults);

        // Arrange
        Assert.Equal("<Results><Resource /></Results>", xml);
    }

    [Theory]
    [InlineData("Q1", "10", "10")]
    [InlineData("OT", "10", "100")]
    public void Serialize_FromResultsWithResourceHasValue_ReturnsHasResourceElementWithAttribute(
        string resourceId,
        string homeValue,
        string awayValue)
    {
        // Arrange
        var resource = string.Format("<Resource Id=\"{0}\" HomeValue=\"{1}\" AwayValue=\"{2}\" />", resourceId, homeValue, awayValue);
        var expectedXml = $"<Results>{resource}</Results>";

        var xmlResource = new XmlResource
        {
            ResourceId = resourceId,
            HomeValue = homeValue,
            AwayValue = awayValue
        };
        var results = new List<XmlResource> { xmlResource };
        var xmlResults = new XmlResults
        {
            Resources = results
        };

        // Act
        var actualXml = service.Serialize(xmlResults);

        // Assert
        Assert.Equal(expectedXml, actualXml);
    }

    [Theory]
    [InlineData("604", "A")]
    [InlineData("605", "H")]
    public void Serialize_FromResultWithResourceHasNoAwayValue(
        string resourceId,
        string homeValue)
    {
        // Arrange
        var expectedXml = string.Format("<Results><Resource Id=\"{0}\" HomeValue=\"{1}\" /></Results>", resourceId, homeValue);
        var resource = new XmlResource
        {
            ResourceId = resourceId,
            HomeValue = homeValue
        };
        var results = new List<XmlResource> { resource };
        var xmlResults = new XmlResults
        {
            Resources = results
        };

        // Act
        var actualXml = service.Serialize(xmlResults);

        // Assert
        Assert.Equal(expectedXml, actualXml);
    }

    [Fact]
    public void Deserialize_EmptyResource_ReturnsResourceIsEmpty()
    {
        // Arrange
        var value = "<Results />";

        // Act
        var xml = service.Deserialize<XmlResults>(value);

        // Assert
        Assert.Empty(xml.Resources);
    }

    [Fact]
    public void Deserialize_HaveResource_ReturnsRightResourceNumber()
    {
        // Arrange
        var value = "<Results><Resource Id=\"225\" HomeValue=\"1\" /><Resource Id=\"221\" HomeValue=\"4\" /></Results>";
        var expectedResourcesNumber = 2;
        // Act
        var xml = service.Deserialize<XmlResults>(value);

        // Arrange
        Assert.Equal(expectedResourcesNumber, xml.Resources.Count);
    }
}