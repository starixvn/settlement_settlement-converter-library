using Fanex.Settlement.Converter.Helpers;
using Xunit;

namespace Fanex.Settlement.Converter.UnitTests.Helpers;

public class BooleanExtensionTests
{
    [Theory]
    [InlineData(true, "1")]
    [InlineData(null, "0")]
    [InlineData(false, "0")]
    public void ToIntString_Always_ReturnsExpectedValue(bool value, string expected)
    {
        // Act
        var actual = value.ToIntString();

        // Assert
        Assert.Equal(expected, actual);
    }
}