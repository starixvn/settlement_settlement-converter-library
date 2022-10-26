using Fanex.Settlement.Converter.Helpers;
using Xunit;

namespace Fanex.Settlement.Converter.UnitTests.Helpers;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("", "", true)]
    [InlineData(null, null, true)]
    [InlineData(null, "", true)]
    [InlineData("1", "1", true)]
    [InlineData(null, "1", false)]
    [InlineData("1", null, false)]
    [InlineData("1", "12", false)]
    public void IgnoreCaseEquals_Always_ReturnsExpectedValue(
       string value1,
       string value2,
       bool expected)
    {
        // Act
        var actual = value1.IgnoreCaseEquals(value2);

        // Assert
        Assert.Equal(expected, actual);
    }
}