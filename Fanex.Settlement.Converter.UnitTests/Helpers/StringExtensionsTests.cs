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

    [Theory]
    [InlineData("HAHAA", "h")]
    [InlineData("HAHAA", "H")]
    public void IgnoreCaseStartsWith_Always_ReturnsTrue(string value1, string value2)
    {
        // Act
        var actual = value1.IgnoreCaseStartsWith(value2);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("HAHAA", "a")]
    [InlineData("HAHAA", "A")]
    public void IgnoreCaseEndsWith_Always_ReturnsTrue(string value1, string value2)
    {
        // Act
        var actual = value1.IgnoreCaseEndsWith(value2);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("abandoned", "abandoned")]
    [InlineData("Abandoned", "abandoned")]
    public void IgnoreCaseContains_Always_ReturnsTrue(string value1, string value2)
    {
        // Act
        var actual = value1.IgnoreCaseContains(value2);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("1FL:0-1;FL", ";FL", 7)]
    [InlineData("1FL:0-1;FL:1-1", "1FL", 0)]
    public void IgnoreCaseIndexOf_Always_ReturnsRightExpected(string value1, string value2, int expected)
    {
        // Act
        var actual = value1.IgnoreCaseIndexOf(value2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Reverse_Always_ReturnsRightExpected()
    {
        var value = "123456";
        // Act
        var actual = value.Reverse();

        // Assert
        var expected = "654321";
        Assert.Equal(expected, actual);
    }
}