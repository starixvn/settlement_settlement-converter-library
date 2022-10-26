using Fanex.Settlement.Converter.Helpers;
using Xunit;

namespace Fanex.Settlement.Converter.UnitTests.Helpers;

public class ScoreExtensionsTests
{
    [Theory]
    [InlineData("", null, null, null, null)]
    [InlineData("FL:2-1;Abandoned 1H;", null, null, 1, 1)]
    [InlineData("FL:2-1;Abandoned 1H;", null, 1, 1, 1)]
    [InlineData("FL:2-1;Abandoned 1H;", 1, null, 1, 1)]
    [InlineData("FL:2-1;Abandoned 2H;", 2, 2, null, null)]
    [InlineData("FL:2-1;Abandoned 2H;", 2, 2, 2, null)]
    [InlineData("FL:2-1;Abandoned 2H;", 2, 2, null, 2)]
    public void IsKeyScore_ScoreIsNullOrEmpty_ReturnsFalse(
        string betStatus,
        int? halfTimeHomeScore,
        int? halfTimeAwayScore,
        int? finalHomeScore,
        int? finalAwayScore)
    {
        // Act
        var actual = betStatus.IsKeyScore(halfTimeHomeScore, halfTimeAwayScore, finalHomeScore, finalAwayScore);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData("", 1, 1, 2, 3)]
    [InlineData("FL:2-1;Abandoned 1H;", 1, 0, null, null)]
    [InlineData("FL:2-1;Abandoned 2H;", null, null, 2, 0)]
    public void IsKeyScore_ScoreIsNotNull_ReturnsTrue(
       string betStatus,
       int? halfTimeHomeScore,
       int? halfTimeAwayScore,
       int? finalHomeScore,
       int? finalAwayScore)
    {
        // Act
        var actual = betStatus.IsKeyScore(halfTimeHomeScore, halfTimeAwayScore, finalHomeScore, finalAwayScore);

        // Assert
        Assert.True(actual);
    }
}